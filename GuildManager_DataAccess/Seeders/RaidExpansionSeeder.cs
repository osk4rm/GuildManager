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
                new RaidExpansion
                {
                    Name = "World of Warcraft Classic",
                    RaidLocations = new List<RaidLocation>(){
                        new RaidLocation { Name = "Blackwing Lair", ImageUrl = "raids/1.png" },
                        new RaidLocation { Name = "Molten Core", ImageUrl = "raids/2.png" },
                        new RaidLocation { Name = "Onyxia's Lair", ImageUrl = "raids/3.png" },
                        new RaidLocation { Name = "Zul'Gurub", ImageUrl = "raids/4.png" },
                        new RaidLocation { Name = "Aq40",  ImageUrl = "raids/5.png" },
                }},
                new RaidExpansion
                {
                    Name = "The Burning Crusade",
                    RaidLocations = new List<RaidLocation>(){
                        new RaidLocation { Name = "Karazhan", ImageUrl = "raids/6.png" },
                        new RaidLocation { Name = "Gruul's Lair", ImageUrl = "raids/7.png" },
                        new RaidLocation { Name = "Magtheridon's Lair", ImageUrl = "raids/8.png" },
                        new RaidLocation { Name = "Serpentshrine Cavern", ImageUrl = "raids/9.png" },
                        new RaidLocation { Name = "Tempest Keep: The Eye", ImageUrl = "raids/10.png" },
                        new RaidLocation { Name = "Black Temple", ImageUrl = "raids/11.png" },
                        new RaidLocation { Name = "Hyjal Summit", ImageUrl = "raids/12.png" },
                        new RaidLocation { Name = "Sunwell Plateau", ImageUrl = "raids/13.png" },
                    }},
                new RaidExpansion { 
                    Name = "Wrath of the Lich King",
                    RaidLocations = new List<RaidLocation>(){
                        new RaidLocation { Name = "Naxxramas", ImageUrl = "raids/14.png" },
                        new RaidLocation { Name = "Ulduar", ImageUrl = "raids/15.png" },
                        new RaidLocation { Name = "Trial of the Crusader", ImageUrl = "raids/16.png" },
                        new RaidLocation { Name = "Icecrown Citadel", ImageUrl = "raids/17.png" },
                    }},
                new RaidExpansion { 
                    Name = "Cataclysm",
                    RaidLocations = new List<RaidLocation>(){
                        new RaidLocation { Name = "Firelands", ImageUrl = "raids/18.png" },
                        new RaidLocation { Name = "Dragon Soul", ImageUrl = "raids/19.png" },
                        new RaidLocation { Name = "Baradin Hold", ImageUrl = "raids/20.png" },
                        new RaidLocation { Name = "Blackwing Descent", ImageUrl = "raids/21.png" },
                        new RaidLocation { Name = "Throne of the Four Winds", ImageUrl = "raids/22.png" },
                    }},
                new RaidExpansion { 
                    Name = "Mists of Pandaria",
                    RaidLocations = new List<RaidLocation>(){
                        new RaidLocation { Name = "Mogu'shan Vaults", ImageUrl = "raids/23.png" },
                        new RaidLocation { Name = "Heart of Fear", ImageUrl = "raids/24.png" },
                        new RaidLocation { Name = "Terrace of Endless Spring", ImageUrl = "raids/25.png" },
                    }},
                new RaidExpansion { 
                    Name = "Warlords of Draenor",
                    RaidLocations = new List<RaidLocation>(){
                        new RaidLocation { Name = "Highmaul", ImageUrl = "raids/26.png" },
                        new RaidLocation { Name = "Blackrock Foundry", ImageUrl = "raids/27.png" },
                        new RaidLocation { Name = "Hellfire Citadel", ImageUrl = "raids/28.png" },
                    }},
                new RaidExpansion { 
                    Name = "Legion" ,
                    RaidLocations = new List<RaidLocation>(){
                        new RaidLocation { Name = "The Emerald Nightmare", ImageUrl = "raids/29.png" },
                        new RaidLocation { Name = "Trial of Valor", ImageUrl = "raids/30.png" },
                        new RaidLocation { Name = "The Nighthold", ImageUrl = "raids/31.png" },
                        new RaidLocation { Name = "Tomb of Sargeras", ImageUrl = "raids/32.png" },
                        new RaidLocation { Name = "Antorus, the Burning Throne", ImageUrl = "raids/33.png" },
                    }},
                new RaidExpansion { 
                    Name = "Battle for Azeroth",
                    RaidLocations = new List<RaidLocation>(){
                        new RaidLocation { Name = "Uldir", ImageUrl = "raids/34.png" },
                        new RaidLocation { Name = "Battle of Dazar'alor", ImageUrl = "raids/35.png" },
                        new RaidLocation { Name = "Crucible of Storms", ImageUrl = "raids/36.png" },
                        new RaidLocation { Name = "The Eternal Palace", ImageUrl = "raids/37.png" },
                        new RaidLocation { Name = "Ny'alotha, the Waking City", ImageUrl = "raids/38.png" },
                    }},
                new RaidExpansion { 
                    Name = "Shadowlands",
                    RaidLocations = new List<RaidLocation>(){
                        new RaidLocation { Name = "Castle Nathria", ImageUrl = "raids/39.png" },
                        new RaidLocation { Name = "Sanctum of Domination", ImageUrl = "raids/40.png" },
                        new RaidLocation { Name = "Sepulcher of the First Ones", ImageUrl = "raids/41.png" },
                    }},
                new RaidExpansion { 
                    Name = "Dragonflight",
                    RaidLocations = new List<RaidLocation>(){
                        new RaidLocation { Name = "Vault of the Incarnates", ImageUrl = "raids/42.png" },
                    }}
            };
        }
    }
}
