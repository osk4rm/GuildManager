using GuildManager_DataAccess;
using GuildManager_DataAccess.Entities;
using GuildManager_IntegrationTests.Helpers;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.EntityFrameworkCore;

namespace GuildManager_IntegrationTests
{
    public class BaseControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        protected TestSeeder _seeder;
        protected WebApplicationFactory<Program> _factory;
        protected HttpClient _httpClient;
        protected HttpClient _unAuthorizedHttpClient;

        private static bool _seeded = false; // Initialization flag
        private static readonly object _seedLock = new object(); // Lock for thread-safety

        public BaseControllerTests(WebApplicationFactory<Program> factory)
        {
            _unAuthorizedHttpClient = factory.CreateClient();
            _factory = factory
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
                });

            _httpClient = _factory.CreateClient();
            _seeder = new TestSeeder(_factory);
            SeedUserOnce();
        }

        private void SeedUserOnce()
        {
            if (!_seeded)
            {
                lock (_seedLock)
                {
                    if (!_seeded)
                    {
                        var user = new User()
                        {
                            Id = 1,
                            Email = "test@user.com",
                            Nickname = "testuser",
                            PasswordHash = "mysecretpassword"
                        };
                        _seeder.SeedEntityAsync(user).Wait(); // Wait is used to ensure the async method completes
                        _seeded = true;
                    }
                }
            }
        }
    }

}
