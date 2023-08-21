using GuildManager_DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GuildManager_IntegrationTests.Validators
{
    public class ValidatorsTestsBase
    {
        protected GuildManagerDbContext _dbContext;

        public ValidatorsTestsBase()
        {
            
        }

        protected void CreateDbContextAndSeed()
        {
            var builder = new DbContextOptionsBuilder<GuildManagerDbContext>();
            builder.UseInMemoryDatabase("TestDB");
            if(_dbContext is null)
            {
                _dbContext = new GuildManagerDbContext(builder.Options);
            }
            if (_dbContext.CharacterClasses.Count() == 0)
                Seed();
        }

        protected void Seed()
        {
            Seeder seeder = new Seeder(_dbContext);
            seeder.Seed();
        }
    }
}