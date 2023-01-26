using GuildManager_DataAccess.Entities.Raids;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.RaidExpansionsAndLocations
{
    public class RaidExpansionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<RaidLocationDto> RaidLocations { get; set; } = new();
    }
}
