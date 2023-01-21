using AutoMapper;
using GuildManager_DataAccess;
using GuildManager_Models;
using GuildManager_Models.Members;
using GuildManagerAPI.Authentication.UserContext;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuildManagerAPI.Services
{
    public class MembersService : IMembersService
    {
        private readonly GuildManagerDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public MembersService(GuildManagerDbContext dbContext, IMapper mapper,
            IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
        }

        public async Task<ServiceResponse<List<MemberDto>>> GetMembers()
        {
            var users = await _dbContext
                .Users
                .Include(u => u.Characters).ThenInclude(c=>c.Class)
                .Include(u => u.Characters).ThenInclude(c=>c.MainSpec)
                .ToListAsync();

            var members = _mapper.Map<List<MemberDto>>(users);

            return new ServiceResponse<List<MemberDto>>
            {
                Data = members,
                Success= true,
                Message = "Success."
            };
        }
    }
}
