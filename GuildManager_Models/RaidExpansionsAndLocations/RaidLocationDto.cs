using GuildManager_DataAccess.Entities.Raids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.RaidExpansionsAndLocations
{
    public class RaidLocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public RaidExpansion Expansion { get; set; } = new();
    }
}
