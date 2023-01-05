using GuildManager_Models;

namespace GuildManager_WebApp.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int?>> RegisterUser(RegisterUserDto dto);
    }
}
