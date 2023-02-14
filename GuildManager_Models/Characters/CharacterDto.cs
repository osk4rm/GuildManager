using GuildManager_DataAccess.Entities;
using GuildManager_Models.CharacterClassesAndSpecs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.Characters
{
    public class CharacterDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public CharacterClassDto Class { get; set; } = new();
        public ClassSpecDto MainSpec { get; set; } = new();
        public decimal ItemLevel { get; set; }
        public int UserId { get; set; }
    }
}
