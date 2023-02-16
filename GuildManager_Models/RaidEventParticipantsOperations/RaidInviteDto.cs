using GuildManager_DataAccess.Enum;
using GuildManager_Models.Auth;
using GuildManager_Models.RaidEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.RaidEventParticipantsOperations
{
    public class RaidInviteDto
    {
        public int RaidEventId { get; set; }
        public string RaidLocation { get; set; }
        public string RaidLocationImg { get; set; }
        public RaidDifficulty RaidDifficulty { get; set; }
        public DateTime RaidStartDate { get; set; }
        public string HostName { get; set; }
        public byte[] HostAvatar { get; set; }
        public string InvitedCharacterName { get; set; }
        public int InvitedCharacterId { get; set; }
    }
}
