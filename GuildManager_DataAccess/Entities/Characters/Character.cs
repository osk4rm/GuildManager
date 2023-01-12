using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ClassId { get; set; }
        public virtual CharacterClass Class { get; set; } = new();
        public int ClassSpecializationId { get; set; }
        public virtual ClassSpecialization MainSpec { get; set; } = new();
        public decimal ItemLevel { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
