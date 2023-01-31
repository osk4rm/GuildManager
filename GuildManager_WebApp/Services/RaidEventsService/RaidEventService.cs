using GuildManager_Models;
using GuildManager_Models.Characters;
using GuildManager_Models.RaidEvents;
using Newtonsoft.Json;
using System.Text;

namespace GuildManager_WebApp.Services.RaidEventsService
{
    public class RaidEventService : IRaidEventService
    {
        private readonly HttpClient _httpClient;

        public RaidEventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<int?>> CreateRaidEvent(UpsertRaidEventDto dto)
        {
            var content = JsonConvert.SerializeObject(dto);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/raid-events/create", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<int?>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<bool?>> DeleteRaidEvent(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/raid-events/delete/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<bool?>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<List<RaidEventDto>>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/raid-events/getall");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<RaidEventDto>>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<RaidEventDto>> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"api/raid-events/get/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<RaidEventDto>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<List<CharacterDto>>> GetParticipants(int eventId)
        {
            var response = await _httpClient.GetAsync($"api/raid-events/participants/{eventId}");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<CharacterDto>>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<List<RaidEventDto>>> GetUserRaidEvents()
        {
            var response = await _httpClient.GetAsync("api/raid-events/getall");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<RaidEventDto>>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<bool?>> JoinRaidEvent(int eventId, int characterId)
        {
            var response = await _httpClient.PostAsync($"api/raid-events/join/{eventId}?characterId={characterId}", null);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<bool?>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<RaidEventDto>> UpdateRaidEvent(UpsertRaidEventDto dto, int id)
        {
            var content = JsonConvert.SerializeObject(dto);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/raid-events/update/{id}", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<RaidEventDto>>(responseContent);

            return result;
        }
    }

}
