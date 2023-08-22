using GuildManager_DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace GuildManager_IntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly string _connectionString;

        public CustomWebApplicationFactory(DatabaseTests fixture)
        {
            _connectionString = fixture.GetConnectionString();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.Remove(services.SingleOrDefault(service => typeof(DbContextOptions<GuildManagerDbContext>) == service.ServiceType));
                services.Remove(services.SingleOrDefault(service => typeof(DbConnection) == service.ServiceType));
                services.AddDbContext<GuildManagerDbContext>((_, option) => option.UseSqlServer(_connectionString));
            });
        }
    }
}
