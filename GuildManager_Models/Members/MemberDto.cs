using GuildManager_DataAccess.Entities;
using GuildManager_Models.Characters;
using GuildManager_Models.RaidEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.Members
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public byte[] Avatar { get; set; }
        public List<CharacterDto> Characters { get; set; } = new();
        public List<RaidEventDto> RaidEvents { get; set; } = new();
    }
}
