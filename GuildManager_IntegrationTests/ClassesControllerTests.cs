using GuildManager_Models.Characters;
using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace GuildManager_IntegrationTests
{
    public class ClassesControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _client;

        public ClassesControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllClasses_ReturnsOkResult()
        {

            var response = await _client.GetAsync("/api/v2/Classes/GetAll");
           
            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        
    }
}
