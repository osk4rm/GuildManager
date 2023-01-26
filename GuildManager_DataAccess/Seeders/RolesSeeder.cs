using GuildManager_DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Seeders
{
    public class RolesSeeder : ISeeder<UserRole>
    {
        public IEnumerable<UserRole> GetSeedData()
        {
            return new[]
            {
                new UserRole{
                    Name= "Admin",
                },
                new UserRole{
                    Name= "Member",
                },
                new UserRole{
                    Name= "Officer",
                },
            };
        }
    }
}
