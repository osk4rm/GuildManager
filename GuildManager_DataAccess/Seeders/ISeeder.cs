using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Seeders
{
    public interface ISeeder<T>
    {
        IEnumerable<T> GetSeedData();
        
    }
}
