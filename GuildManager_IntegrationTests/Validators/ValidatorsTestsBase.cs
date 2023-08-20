using GuildManager_DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GuildManager_IntegrationTests.Validators
{
    public class ValidatorsTestsBase
    {
        protected GuildManagerDbContext _dbContext;

        public ValidatorsTestsBase()
        {
            var builder = new DbContextOptionsBuilder<GuildManagerDbContext>();
            builder.UseInMemoryDatabase("TestDB");
            _dbContext = new GuildManagerDbContext(builder.Options);
            Seed();
        }

        protected void Seed()
        {
            Seeder seeder = new Seeder(_dbContext);
            seeder.Seed();
        }
    }
}