using GuildManager_Models;
using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManager_Models.RaidEvents;
using Newtonsoft.Json;
using System.Net.Http;

namespace GuildManager_WebApp.Services.DashboardStatsService
{
    public class StatsService : IStatsService
    {
        private readonly HttpClient _httpClient;

        public StatsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ServiceResponse<int?>> GetGuildMembersCount()
        {
            var response = await _httpClient.GetAsync("api/stats/members-count");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<int?>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<int?>> GetPendingInvitesCount()
        {
            var response = await _httpClient.GetAsync("api/stats/pending-invites");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<int?>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<int?>> GetRaidsThisWeekCount()
        {
            var response = await _httpClient.GetAsync("api/stats/raids-this-week");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<int?>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<RaidEventDto>> GetUpcomingEvent()
        {
            var response = await _httpClient.GetAsync("api/raid-events/upcoming-event");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<RaidEventDto>>(responseContent);

            return result;
        }
    }
}
