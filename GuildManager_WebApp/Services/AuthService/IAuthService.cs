using GuildManager_Models;

namespace GuildManager_WebApp.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int?>> RegisterUser(RegisterUserDto dto);
        Task<ServiceResponse<string>> LoginUser(LoginDto dto);
        Task<ServiceResponse<bool>> ChangePassword(ChangePasswordDto dto);
    }
}
