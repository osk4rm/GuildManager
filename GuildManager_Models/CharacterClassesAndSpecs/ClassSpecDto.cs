using GuildManager_DataAccess.Entities.Characters.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.CharacterClassesAndSpecs
{
    public class ClassSpecDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ClassSpecializationRole Role { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
