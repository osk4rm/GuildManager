﻿using GuildManager_DataAccess.Entities;
using GuildManager_DataAccess.Entities.Raids;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess
{
    public class GuildManagerDbContext : DbContext
    {
        public GuildManagerDbContext(DbContextOptions<GuildManagerDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterClass> CharacterClasses { get; set; }
        public DbSet<ClassSpecialization> ClassSpecializations { get; set; }
        public DbSet<RaidEvent> RaidEvents { get; set; }
        public DbSet<RaidLocation> RaidLocations { get; set; }

    }
}
