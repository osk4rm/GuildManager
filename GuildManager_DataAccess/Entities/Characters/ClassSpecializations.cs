using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Entities
{
    public class ClassSpecializations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CharacterClass Class { get; set; }
    }
}
