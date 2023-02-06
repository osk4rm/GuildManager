using GuildManager_DataAccess;
using GuildManager_DataAccess.Entities;
using GuildManagerAPI.Authentication;
using GuildManagerAPI.Exceptions;
using GuildManager_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GuildManagerAPI.Services.Interfaces;
using GuildManager_Models.Auth;
using GuildManagerAPI.Authentication.UserContext;
using AutoMapper;

namespace GuildManagerAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly GuildManagerDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;

        public LoginService(GuildManagerDbContext context, 
            IPasswordHasher<User> passwordHasher, 
            AuthenticationSettings authenticationSettings,
            IUserContextService userContextService,
            IMapper mapper)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
            _userContextService = userContextService;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(int userId, ChangePasswordDto dto)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new NotFoundException($"User {userId} not found");
            }
            var hashedPassword = _passwordHasher.HashPassword(user, dto.Password);
            user.PasswordHash = hashedPassword;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Data = true,
                Success = true,
                Message = "Your password has been changed."
            };

        }

        public ServiceResponse<string> GenerateJwt(LoginDto dto)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == dto.Email);
            if (user == null)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Nickname),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();


            return new ServiceResponse<string>
            {
                Data = tokenHandler.WriteToken(token),
                Success = true,
                Message = string.Empty
            };
        }

        public async Task<ServiceResponse<UserInfoDto>> GetUserInfo()
        {
            var userId = _userContextService.Id;

            if(userId == null)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            var userFromDb = await _context
                .Users
                .Include(u=>u.Role)
                .FirstOrDefaultAsync(x=>x.Id== userId);

            if(userFromDb == null)
            {
                throw new NotFoundException("User not found.");
            }

            var userDto = _mapper.Map<UserInfoDto>(userFromDb);

            return new ServiceResponse<UserInfoDto>
            {
                Data = userDto,
                Success = true
            };
        }

        public ServiceResponse<int> RegisterUser(RegisterUserDto dto)
        {
            var memberRole = _context.Roles.FirstOrDefault(r => r.Name == "Member");
            if (memberRole == null)
            {
                throw new NotFoundException("Member role not found. Check your database.");
            }
            var user = new User()
            {
                Email = dto.Email,
                Nickname = dto.Nickname,
                RoleId = memberRole.Id,

            };
            using (var stream = new FileStream(Path.Combine("wwwroot", "default_avatar.jpg"), FileMode.Open))
            {
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
                user.Avatar = bytes;
            }

            var hashedPassword = _passwordHasher.HashPassword(user, dto.Password);
            user.PasswordHash = hashedPassword;

            _context.Users.Add(user);
            _context.SaveChanges();

            return new ServiceResponse<int>
            {
                Success = true,
                Data = user.Id,
                Message = "Registration successful!"
            };
        }

        public async Task<ServiceResponse<UserInfoDto>> UpdateUserAvatar(byte[] avatar)
        {
            var userId = _userContextService.Id;

            if (userId == null)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            var userFromDb = await _context
                .Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (userFromDb == null)
            {
                throw new NotFoundException("User not found.");
            }

            userFromDb.Avatar = avatar;

            _context.Update(userFromDb);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<UserInfoDto>(userFromDb);

            return new ServiceResponse<UserInfoDto>
            {
                Data = dto,
                Success = true,
                Message = "Avatar updated."
            };
        }
    }
}
