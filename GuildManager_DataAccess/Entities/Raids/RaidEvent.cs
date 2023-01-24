using GuildManager_DataAccess.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Entities.Raids
{
    public class RaidEvent
    {
        public int Id { get; set; }
        public int RaidLocationId { get; set; }
        public virtual RaidLocation RaidLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public virtual List<Character> Participants { get; set; } = new();
        public bool AutoAccept { get; set; } = false;
        public RaidDifficulty RaidDifficulty { get; set; }
    }
}
