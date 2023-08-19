using GuildManager_DataAccess;

namespace GuildManager_IntegrationTests.Helpers
{
    public class TestSeeder
    {
        private readonly WebApplicationFactory<Program> _factory;

        public TestSeeder(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        public async Task SeedEntityAsync<TEntity>(TEntity entity) where TEntity : class
        {
            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<GuildManagerDbContext>();
            dbContext.Add(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
