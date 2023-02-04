using GuildManager_DataAccess.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Entities.Raids
{
    public class RaidEventCharacter
    {
        public int RaidEventId { get; set; }
        public RaidEvent RaidEvent { get; set; }

        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public AcceptanceStatus AcceptanceStatus { get; set; }
    }
}
