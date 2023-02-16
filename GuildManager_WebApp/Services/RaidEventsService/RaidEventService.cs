using GuildManager_Models;
using GuildManager_Models.Characters;
using GuildManager_Models.RaidEvents;
using Newtonsoft.Json;
using Sieve.Models;
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

        public async Task<ServiceResponse<int?>> CreateCommentForRaidEvent(int eventId, string message)
        {
            var content = JsonConvert.SerializeObject(message);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/raid-events/{eventId}/comments/create", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<int?>>(responseContent);

            return result;
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

        public async Task<ServiceResponse<bool?>> DeleteCommentForRaidEvent(int commentId)
        {
            var response = await _httpClient.DeleteAsync($"api/raid-events/comments/delete/{commentId}");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<bool?>>(responseContent);

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

        public async Task<ServiceResponse<List<CommentDto>>> GetCommentsForRaidEvent(int eventId)
        {
            var response = await _httpClient.GetAsync($"api/raid-events/{eventId}/comments");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<CommentDto>>>(responseContent);

            return result;
        }

        public async Task<PagedServiceResponse<List<RaidEventDto>>> GetPagedRaidEvents(SieveModel sieveModel)
        {
            var content = JsonConvert.SerializeObject(sieveModel);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/raid-events/get-paged", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PagedServiceResponse<List<RaidEventDto>>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<List<RaidEventCharacterDto>>> GetParticipants(int eventId)
        {
            var response = await _httpClient.GetAsync($"api/raid-events/participants/{eventId}");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<RaidEventCharacterDto>>>(responseContent);

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

        public async Task<ServiceResponse<CommentDto>> UpdateCommentForRaidEvent(int commentId, string message)
        {
            var content = JsonConvert.SerializeObject(message);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/raid-events/comments/update/{commentId}", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<CommentDto>>(responseContent);

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
