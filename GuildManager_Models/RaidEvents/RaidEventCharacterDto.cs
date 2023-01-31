using GuildManager_DataAccess.Entities.Raids;
using GuildManager_DataAccess.Entities;
using GuildManager_DataAccess.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildManager_Models.Characters;

namespace GuildManager_Models.RaidEvents
{
    public class RaidEventCharacterDto
    {
        public int RaidEventId { get; set; }
        public int CharacterId { get; set; }
        public CharacterDto Character { get; set; }

        public AcceptanceStatus AcceptanceStatus { get; set; }
    }
}
