using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Entities.Raids
{
    public class Comment
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }

        public string Message { get; set; }
        public int RaidEventId { get; set; }
        public virtual RaidEvent RaidEvent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
