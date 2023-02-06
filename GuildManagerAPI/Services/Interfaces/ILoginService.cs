using GuildManager_Models;
using GuildManager_Models.Auth;

namespace GuildManagerAPI.Services.Interfaces
{
    public interface ILoginService
    {
        ServiceResponse<string> GenerateJwt(LoginDto dto);
        ServiceResponse<int> RegisterUser(RegisterUserDto dto);
        Task<ServiceResponse<bool>> ChangePassword(int userId, ChangePasswordDto dto);
        Task<ServiceResponse<UserInfoDto>> GetUserInfo();
        Task<ServiceResponse<UserInfoDto>> UpdateUserAvatar(byte[] avatar);
        
    }
}