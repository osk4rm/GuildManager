using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.Auth
{
    public class UserInfoDto
    {
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Role { get; set; }
        public byte[] Avatar { get; set; }
    }
}
