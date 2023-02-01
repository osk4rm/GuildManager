using GuildManager_DataAccess.Enum;
using GuildManager_Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.RaidEvents
{
    public class UpdateRaidEventCharacterDto
    {
        public int RaidEventId { get; set; }
        public int CharacterId { get; set; }
        public AcceptanceStatus AcceptanceStatus { get; set; }
    }
}
