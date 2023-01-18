﻿using GuildManager_DataAccess.Entities;
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
        public async Task<ServiceResponse<List<CharacterClass>>> GetClasses()
        {
            var response = await _httpClient.GetAsync("api/classes");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<CharacterClass>>>(responseContent);

            return result;
        }
    }
}
