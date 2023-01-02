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
        public string Name { get; set; }
        public int ClassId { get; set; }
        public virtual CharacterClass Class { get; set; }
    }
}
