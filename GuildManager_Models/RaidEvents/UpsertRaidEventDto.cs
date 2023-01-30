using GuildManager_DataAccess.Enum;
using GuildManager_Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.RaidEvents
{
    public class UpsertRaidEventDto
    {
        [Required]
        public int RaidLocationId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public bool AutoAccept { get; set; } = false;
        public RaidDifficulty RaidDifficulty { get; set; }
        public RaidStatus Status { get; set; }

    }
}
