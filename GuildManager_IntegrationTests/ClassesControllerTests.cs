using GuildManager_Models.Characters;
using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace GuildManager_IntegrationTests
{
    public class ClassesControllerTests : BaseControllerTests
    {
        public ClassesControllerTests(WebApplicationFactory<Program> factory) : base(factory) { }


        [Fact]
        public async Task GetAllClasses_ReturnsOkResult()
        {
            //act
            var response = await _httpClient.GetAsync("/api/v2/Classes/GetAll");
           
            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetClassCount_ReturnsOkResult()
        {
            //act
            var response = await _httpClient.GetAsync("/api/v2/Classes/GetClassCount");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetRoleCount_ReturnsOkResult()
        {
            //act
            var response = await _httpClient.GetAsync("/api/v2/Classes/GetRoleCount");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

    }
}
