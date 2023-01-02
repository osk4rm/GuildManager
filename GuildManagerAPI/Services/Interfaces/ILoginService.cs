using GuildManagerAPI.Models.Auth;

namespace GuildManagerAPI.Services
{
    public interface ILoginService
    {
        string GenerateJwt(LoginDto dto);
        void RegisterUser(RegisterUserDto dto);
    }
}