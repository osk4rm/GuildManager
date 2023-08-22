using Testcontainers.MsSql;

namespace GuildManager_IntegrationTests
{
    public sealed class DatabaseTests : IAsyncLifetime
    {
        private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder().Build();

        public Task InitializeAsync()
        {
            return _msSqlContainer.StartAsync();
        }

        public Task DisposeAsync()
        {
            return _msSqlContainer.DisposeAsync().AsTask();
        }

        public string GetConnectionString()
        {
            return _msSqlContainer.GetConnectionString();
        }
    }
}
