using GuildManager_Models;
using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManager_Models.Characters;
using Newtonsoft.Json;
using System.Text;

namespace GuildManager_WebApp.Services.CharactersService
{
    public class CharacterService : ICharacterService
    {
        private readonly HttpClient _httpClient;

        public CharacterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<int?>> CreateCharacter(CreateCharacterDto characterDto)
        {
            var content = JsonConvert.SerializeObject(characterDto);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/characters/create", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<int?>>(responseContent);

            return result;
        }

        public async Task<ServiceResponse<List<CharacterDto>>> GetUserCharacters()
        {
            var response = await _httpClient.GetAsync("api/characters/getusercharacters");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<CharacterDto>>>(responseContent);

            return result;
        }
    }
}
