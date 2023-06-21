using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace GuildManager_IntegrationTests
{
    public class ClassesTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ClassesTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAllClasses_ReturnsOkResponse()
        {
            // Arrange
            var client = _factory.CreateClient();
            var expectedStatusCode = HttpStatusCode.OK;

            // Act
            var response = await client.GetAsync("/api/v2/Classes/GetAll");

            // Assert
            Assert.Equal(expectedStatusCode, response.StatusCode);
        }
        [Fact]
        public async Task GetAllClasses_ReturnsOkResult()
        {
            var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();

            var response = await client.GetAsync("/api/v2/Classes/GetAll");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

    }
}
