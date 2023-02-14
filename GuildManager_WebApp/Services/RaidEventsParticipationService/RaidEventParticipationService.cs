using GuildManager_Models;
using GuildManager_Models.RaidEventParticipantsOperations;
using GuildManager_Models.RaidEvents;
using Newtonsoft.Json;
using Sieve.Models;
using System.Net.Http;
using System.Text;

namespace GuildManager_WebApp.Services.RaidEventsParticipationService
{
    public class RaidEventParticipationService : IRaidEventParticipationService
    {
        private readonly HttpClient _httpClient;

        public RaidEventParticipationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PagedServiceResponse<List<RaidInviteDto>>> GetUserRaidInvites(SieveModel sieveModel)
        {
            var content = JsonConvert.SerializeObject(sieveModel);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/raid-events/invites/get-user-invites", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PagedServiceResponse<List<RaidInviteDto>>>(responseContent);

            return result;
        }
    }
}
