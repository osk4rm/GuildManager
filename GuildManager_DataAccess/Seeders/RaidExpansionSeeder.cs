using GuildManager_DataAccess.Entities.Raids;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Seeders
{
    public class RaidExpansionSeeder : ISeeder<RaidExpansion>
    {
        public IEnumerable<RaidExpansion> GetSeedData()
        {
            return new[]
            {
                new RaidExpansion { Id = 1, Name = "World of Warcraft Classic"},
                new RaidExpansion { Id = 2, Name = "The Burning Crusade" },
                new RaidExpansion { Id = 3, Name = "Wrath of the Lich King" },
                new RaidExpansion { Id = 4, Name = "Cataclysm" },
                new RaidExpansion { Id = 5, Name = "Mists of Pandaria" },
                new RaidExpansion { Id = 6, Name = "Warlords of Draenor" },
                new RaidExpansion { Id = 7, Name = "Legion" },
                new RaidExpansion { Id = 8, Name = "Battle for Azeroth" },
                new RaidExpansion { Id = 9, Name = "Shadowlands" },
                new RaidExpansion { Id = 10, Name = "Dragonflight" }
            };
        }
    }
}
