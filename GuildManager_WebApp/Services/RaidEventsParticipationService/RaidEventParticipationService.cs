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

        public async Task<ServiceResponse<bool?>> InviteForRaidEvent(int eventId, int characterId)
        {
            var response = await _httpClient.PostAsync($"api/raid-events/invite/{eventId}?characterId={characterId}", null);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<bool?>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<bool?>> CancelApplicationForRaidEvent(int eventId, int characterId)
        {
            var response = await _httpClient.DeleteAsync($"/api/raid-events/{eventId}/remove-application?characterId={characterId}");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<bool?>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<RaidEventCharacterDto>> UpdateCharacterAcceptanceStatus(UpdateRaidEventCharacterDto dto)
        {
            var content = JsonConvert.SerializeObject(dto);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/raid-events/participants/update-status", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<RaidEventCharacterDto>>(responseContent);

            return result;
        }
    }
}
