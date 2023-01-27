using GuildManager_DataAccess.Entities.Raids;
using GuildManager_DataAccess.Entities;
using GuildManager_DataAccess.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildManager_Models.RaidExpansionsAndLocations;
using GuildManager_Models.Characters;

namespace GuildManager_Models.RaidEvents
{
    public class RaidEventDto
    {
        public int Id { get; set; }
        public RaidLocationDto RaidLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public List<CharacterDto> Participants { get; set; } = new();
        public bool AutoAccept { get; set; } = false;
        public RaidDifficulty RaidDifficulty { get; set; } = RaidDifficulty.Normal;
        public RaidStatus Status { get; set; } = RaidStatus.Open;
        public string LeaderName { get; set; }
        public int LeaderId { get; set; }
    }
}
