using GuildManager_DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess
{
    internal class Seeder
    {
        public static IEnumerable<UserRole> DefaultUserRoles()
        {
            return new[]
            {
                new UserRole{
                    Id = 1,
                    Name= "Admin",
                },
                new UserRole{
                    Id = 2,
                    Name= "Member",
                },
                new UserRole{
                    Id = 3,
                    Name= "Officer",
                },
            };
        }
    }
}
