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
        public int ClassId { get; set; } = new();
        public int ClassSpecializationId { get; set; } = new();
        public decimal ItemLevel { get; set; }
    }
}
