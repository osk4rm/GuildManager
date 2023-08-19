using GuildManager_DataAccess;
using GuildManager_DataAccess.Entities;
using GuildManager_IntegrationTests.Helpers;
using GuildManager_Models;
using GuildManager_Models.Characters;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace GuildManager_IntegrationTests
{
    public class CharactersControllerTests : BaseControllerTests
    {
        public CharactersControllerTests(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetUserCharacters_WithCorrectAuthentication_ReturnsOk()
        {
            //act
            var response = await _httpClient.GetAsync("/api/v2/Characters/GetUserCharacters");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
        [Fact]
        public async Task GetUserCharacters_WithNoAuthentication_ReturnsUnauthorizedResult()
        {
            //arrange
            

            //act
            var response = await _unAuthorizedHttpClient.GetAsync("/api/v2/Characters/GetUserCharacters");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Create_WithValidModel_ReturnsOkWithResultId()
        {
            //arrange 
            var model = new CreateCharacterDto()
            {
                Name = "TestCharacter",
                ItemLevel = 350,
                ClassSpecializationId = 1,
                ClassId = 1
            };

            //act
            var response = await _httpClient.PostAsync("/api/v2/Characters/Create", model.ToJsonHttpContent());
            var contentString = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<ServiceResponse<int?>>(contentString);

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            content.Data.Should().NotBeNull();
        }

        //nie wchodzi do walidatora, zadziała po zaimplementowaniu mediatora
        [Fact]
        public async Task Create_WithInvalidModel_ReturnsBadRequest()
        {
            //arrange
            var model = new CreateCharacterDto()
            {
                Name = "TestCharacter",
                ItemLevel = 350,
                ClassSpecializationId = 1,
                ClassId = -1
            };
            
            //act
            var response = await _httpClient.PostAsync("/api/v2/Characters/Create", model.ToJsonHttpContent());

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Delete_ForNonExistingCharacter_ReturnsNotFound()
        {
            //arrange

            //act
            var response = await _httpClient.DeleteAsync($"/api/v2/Characters/Delete?id=0");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Delete_ForExistingCharacter_ReturnsOk()
        {
            //arrange
            var character = new Character()
            {
                ClassSpecializationId = 39,
                ClassId = 14,
                Id = 1,
                Name = "Test",
                UserId = 1
            };

            await _seeder.SeedEntityAsync(character);

            //act
            var response = await _httpClient.DeleteAsync($"/api/v2/Characters/Delete?id={character.Id}");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        
    }
}
