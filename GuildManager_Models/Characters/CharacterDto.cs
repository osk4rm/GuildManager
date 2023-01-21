using GuildManager_DataAccess.Entities;
using GuildManager_Models.CharacterClassesAndSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.Characters
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public CharacterClassDto Class { get; set; } = new();
        public ClassSpecDto MainSpec { get; set; } = new();
        public decimal ItemLevel { get; set; }
    }
}
