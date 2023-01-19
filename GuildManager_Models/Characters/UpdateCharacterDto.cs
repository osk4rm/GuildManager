using GuildManager_DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.Characters
{
    public class UpdateCharacterDto
    {
        public int Id { get; set; }
        public int? MainSpecId { get; set; } 
        public decimal? ItemLevel { get; set; }
    }
}
