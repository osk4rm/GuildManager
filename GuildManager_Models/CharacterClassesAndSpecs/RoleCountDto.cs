using GuildManager_DataAccess.Entities.Characters.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.CharacterClassesAndSpecs
{
    public class RoleCountDto
    {
        public ClassSpecializationRole Role { get; set; }
        public int RoleCount { get; set; }
    }
}
