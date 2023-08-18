using GuildManager_DataAccess;
using GuildManager_Models;
using GuildManager_Models.Characters;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace GuildManager_IntegrationTests
{
    public class CharactersTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;

        public CharactersTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<GuildManagerDbContext>));

                        services.Remove(dbContextOptions);
                        services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();

                        services.AddMvc(opts => opts.Filters.Add(new FakeUserFilter()));

                        services.AddDbContext<GuildManagerDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("GMTestDB");
                        });
                    });
                })
                .CreateClient();
        }

        [Fact]
        public async Task GetUserCharacters_WithNoAuthentication_ReturnsUnauthorizedResult()
        {
            //arrange
            

            //act
            var response = await _httpClient.GetAsync("/api/v2/Characters/GetUserCharacters");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }

        //ZWRACA USER NOT FOUND (404), TODO: zrobić seedowanie fake'owej bazy
        [Fact]
        public async Task Create_WithValidModel_ReturnsOkWithResultId()
        {
            //arrange 
            var model = new CreateCharacterDto()
            {
                Name = "TestCharacter",
                ItemLevel = 350,
                ClassSpecializationId = 39,
                ClassId = 14
            };
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //act
            var response = await _httpClient.PostAsync("/api/v2/Characters/Create", httpContent);
            var contentString = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<ServiceResponse<int?>>(contentString);

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            content.Data.Should().NotBeNull();
        }
    }
}
