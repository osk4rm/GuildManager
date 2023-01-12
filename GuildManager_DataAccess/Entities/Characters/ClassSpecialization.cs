using GuildManager_DataAccess.Entities.Characters.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Entities
{
    public class ClassSpecialization
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CharacterClassId { get; set; }
        public virtual CharacterClass CharacterClass { get; set; }
        public ClassSpecializationRole Role { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
