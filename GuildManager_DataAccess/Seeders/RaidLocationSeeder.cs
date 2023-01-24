using GuildManager_DataAccess.Entities.Raids;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Seeders
{
    public class RaidLocationSeeder : ISeeder<RaidLocation>
    {
        public IEnumerable<RaidLocation> GetSeedData()
        {
            return new[]
            {
                new RaidLocation { Id = 1, Name = "Blackwing Lair", RaidExpansionId = 1, ImageUrl = "raids/1.png" },
                new RaidLocation { Id = 2, Name = "Molten Core", RaidExpansionId = 1, ImageUrl = "raids/2.png" },
                new RaidLocation { Id = 3, Name = "Onyxia's Lair", RaidExpansionId = 1, ImageUrl = "raids/3.png" },
                new RaidLocation { Id = 4, Name = "Zul'Gurub", RaidExpansionId = 1, ImageUrl = "raids/4.png" },
                new RaidLocation { Id = 5, Name = "Aq40", RaidExpansionId = 1, ImageUrl = "raids/5.png" },
                new RaidLocation { Id = 6, Name = "Karazhan", RaidExpansionId = 2, ImageUrl = "raids/6.png" },
                new RaidLocation { Id = 7, Name = "Gruul's Lair", RaidExpansionId = 2, ImageUrl = "raids/7.png" },
                new RaidLocation { Id = 8, Name = "Magtheridon's Lair", RaidExpansionId = 2, ImageUrl = "raids/8.png" },
                new RaidLocation { Id = 9, Name = "Serpentshrine Cavern", RaidExpansionId = 2, ImageUrl = "raids/9.png" },
                new RaidLocation { Id = 10, Name = "Tempest Keep: The Eye", RaidExpansionId = 2, ImageUrl = "raids/10.png" },
                new RaidLocation { Id = 11, Name = "Black Temple", RaidExpansionId = 2, ImageUrl = "raids/11.png" },
                new RaidLocation { Id = 12, Name = "Hyjal Summit", RaidExpansionId = 2, ImageUrl = "raids/12.png" },
                new RaidLocation { Id = 13, Name = "Sunwell Plateau", RaidExpansionId = 2, ImageUrl = "raids/13.png" },
                new RaidLocation { Id = 14, Name = "Naxxramas", RaidExpansionId = 3, ImageUrl = "raids/14.png" },
                new RaidLocation { Id = 15, Name = "Ulduar", RaidExpansionId = 3, ImageUrl = "raids/15.png" },
                new RaidLocation { Id = 16, Name = "Trial of the Crusader", RaidExpansionId = 3, ImageUrl = "raids/16.png" },
                new RaidLocation { Id = 17, Name = "Icecrown Citadel", RaidExpansionId = 3, ImageUrl = "raids/17.png" },
                new RaidLocation { Id = 18, Name = "Firelands", RaidExpansionId = 4, ImageUrl = "raids/18.png" },
                new RaidLocation { Id = 19, Name = "Dragon Soul", RaidExpansionId = 4, ImageUrl = "raids/19.png" },
                new RaidLocation { Id = 20, Name = "Baradin Hold", RaidExpansionId = 4, ImageUrl = "raids/20.png" },
                new RaidLocation { Id = 21, Name = "Blackwing Descent", RaidExpansionId = 4, ImageUrl = "raids/21.png" },
                new RaidLocation { Id = 22, Name = "Throne of the Four Winds", RaidExpansionId = 4, ImageUrl = "raids/22.png" },
                new RaidLocation { Id = 23, Name = "Mogu'shan Vaults", RaidExpansionId = 5, ImageUrl = "raids/23.png" },
                new RaidLocation { Id = 24, Name = "Heart of Fear", RaidExpansionId = 5, ImageUrl = "raids/24.png" },
                new RaidLocation { Id = 25, Name = "Terrace of Endless Spring", RaidExpansionId = 5, ImageUrl = "raids/25.png" },
                new RaidLocation { Id = 26, Name = "Highmaul", RaidExpansionId = 6, ImageUrl = "raids/26.png" },
                new RaidLocation { Id = 27, Name = "Blackrock Foundry", RaidExpansionId = 6, ImageUrl = "raids/27.png" },
                new RaidLocation { Id = 28, Name = "Hellfire Citadel", RaidExpansionId = 6, ImageUrl = "raids/28.png" },
                new RaidLocation { Id = 29, Name = "The Emerald Nightmare", RaidExpansionId = 7, ImageUrl = "raids/29.png" },
                new RaidLocation { Id = 30, Name = "Trial of Valor", RaidExpansionId = 7, ImageUrl = "raids/30.png" },
                new RaidLocation { Id = 31, Name = "The Nighthold", RaidExpansionId = 7, ImageUrl = "raids/31.png" },
                new RaidLocation { Id = 32, Name = "Tomb of Sargeras", RaidExpansionId = 7, ImageUrl = "raids/32.png" },
                new RaidLocation { Id = 33, Name = "Antorus, the Burning Throne", RaidExpansionId = 7, ImageUrl = "raids/33.png" },
                new RaidLocation { Id = 34, Name = "Uldir", RaidExpansionId = 8, ImageUrl = "raids/34.png" },
                new RaidLocation { Id = 35, Name = "Battle of Dazar'alor", RaidExpansionId = 8, ImageUrl = "raids/35.png" },
                new RaidLocation { Id = 36, Name = "Crucible of Storms", RaidExpansionId = 8, ImageUrl = "raids/36.png" },
                new RaidLocation { Id = 37, Name = "The Eternal Palace", RaidExpansionId = 8, ImageUrl = "raids/37.png" },
                new RaidLocation { Id = 38, Name = "Ny'alotha, the Waking City", RaidExpansionId = 8, ImageUrl = "raids/38.png" },
                new RaidLocation { Id = 39, Name = "Castle Nathria", RaidExpansionId = 9, ImageUrl = "raids/39.png" },
                new RaidLocation { Id = 40, Name = "Sanctum of Domination", RaidExpansionId = 9, ImageUrl = "raids/40.png" },
                new RaidLocation { Id = 41, Name = "Sepulcher of the First Ones", RaidExpansionId = 9, ImageUrl = "raids/41.png" },
                new RaidLocation { Id = 42, Name = "Vault of the Incarnates", RaidExpansionId = 10, ImageUrl = "raids/42.png" },
            };
        }
    }
}
