using GuildManager_DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.Characters
{
    public class CreateCharacterDto
    {
        public string Name { get; set; } = string.Empty;
        public CharacterClass Class { get; set; } = new();
        public ClassSpecialization MainSpec { get; set; } = new();
        public decimal ItemLevel { get; set; }
    }
}
