using GuildManager_Models;
using System.Net.Http.Json;

namespace GuildManager_WebApp.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> RegisterUser(RegisterUserDto dto)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/register", dto);
            

            return result;
        }
    }
}
