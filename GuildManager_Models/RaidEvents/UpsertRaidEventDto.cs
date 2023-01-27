using GuildManager_DataAccess.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.RaidEvents
{
    public class UpsertRaidEventDto
    {
        public int RaidLocationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public bool AutoAccept { get; set; } = false;
        public RaidDifficulty RaidDifficulty { get; set; }
        public RaidStatus Status { get; set; }

    }
}
