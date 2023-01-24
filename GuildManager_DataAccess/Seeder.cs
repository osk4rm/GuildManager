using EFCore.BulkExtensions;
using GuildManager_DataAccess.Entities;
using GuildManager_DataAccess.Entities.Characters.Enum;
using GuildManager_DataAccess.Seeders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess
{
    public class Seeder
    {
        private readonly GuildManagerDbContext _dbContext;

        public Seeder(GuildManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                SeedData(new RolesSeeder(), _dbContext.Roles);
                SeedData(new CharacterClassesSeeder(), _dbContext.CharacterClasses);
                SeedData(new ClassSpecSeeder(), _dbContext.ClassSpecializations);
                SeedData(new RaidExpansionSeeder(), _dbContext.RaidExpansions);
                SeedData(new RaidLocationSeeder(), _dbContext.RaidLocations);

            }
        }

        private void SeedData<T>(ISeeder<T> seeder, DbSet<T> entity) where T : class
        {
            var data = seeder.GetSeedData().ToList();
            _dbContext.BulkInsertOrUpdate(data);
            _dbContext.SaveChanges();
        }

       
    }
}
