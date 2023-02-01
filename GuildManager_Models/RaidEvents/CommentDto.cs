using GuildManager_Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.RaidEvents
{
    public class CommentDto
    {
        public int Id { get; set; }
        public MemberDto Author { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
