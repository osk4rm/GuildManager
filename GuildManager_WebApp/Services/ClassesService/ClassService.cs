using GuildManager_DataAccess.Entities;
using GuildManager_Models;
using GuildManager_Models.CharacterClassesAndSpecs;
using Newtonsoft.Json;

namespace GuildManager_WebApp.Services.ClassesService
{
    public class ClassService : IClassService
    {
        private readonly HttpClient _httpClient;

        public ClassService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ServiceResponse<List<CharacterClassDto>>> GetClasses()
        {
            var response = await _httpClient.GetAsync("api/classes");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<CharacterClassDto>>>(responseContent);

            return result;
        }
        public async Task<ServiceResponse<List<ClassCountDto>>> GetClassCount()
        {
            var response = await _httpClient.GetAsync("api/classes/classcount");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<ClassCountDto>>>(responseContent);

            return result;
        }
        public async Task<ServiceResponse<List<RoleCountDto>>> GetRoleCount()
        {
            var response = await _httpClient.GetAsync("api/classes/rolecount");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<RoleCountDto>>>(responseContent);

            return result;
        }
    }
}
