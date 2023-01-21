using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManager_Models;
using Newtonsoft.Json;
using System.Net.Http;
using GuildManager_Models.Members;

namespace GuildManager_WebApp.Services.MembersService
{
    public class MembersService : IMembersService
    {
        private readonly HttpClient _httpClient;

        public MembersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ServiceResponse<List<MemberDto>>> GetMembers()
        {
            var response = await _httpClient.GetAsync("api/members/getmembers");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<MemberDto>>>(responseContent);

            return result;
        }
    }
}
