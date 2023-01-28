using GuildManager_Models;
using GuildManager_Models.RaidEvents;
using GuildManager_Models.RaidExpansionsAndLocations;
using Newtonsoft.Json;
using System.Net.Http;

namespace GuildManager_WebApp.Services.ExpansionsAndLocationsService
{
    public class ExpansionsLocationsService : IExpansionsLocationsService
    {
        private readonly HttpClient _httpClient;

        public ExpansionsLocationsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ServiceResponse<List<RaidExpansionDto>>> GetAllExpansions()
        {
            var response = await _httpClient.GetAsync("api/expansions");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<RaidExpansionDto>>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<List<RaidLocationDto>>> GetAllLocations()
        {
            var response = await _httpClient.GetAsync("api/raid-locations");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<RaidLocationDto>>>(responseContent);

            return result;
        }
    }
}
