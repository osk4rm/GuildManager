using GuildManager_Models;
using GuildManager_Models.Auth;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace GuildManager_WebApp.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<bool?>> ChangePassword(ChangePasswordDto dto)
        {
            var result = await _httpClient.PostAsJsonAsync("api/change-password", dto);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool?>>();
        }

        public async Task<ServiceResponse<UserInfoDto>> GetUserInfo()
        {
            var response = await _httpClient.GetAsync("api/getuserinfo");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<UserInfoDto>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<string>> LoginUser(LoginDto dto)
        {
            var content = JsonConvert.SerializeObject(dto);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/login", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<string>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<int?>> RegisterUser(RegisterUserDto dto)
        {
            var content = JsonConvert.SerializeObject(dto);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/register", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<int?>>(responseContent);

            return result;
        }
    }
}
