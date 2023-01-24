using GuildManager_DataAccess.Entities.Raids;
using GuildManager_DataAccess.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Entities.Configurations
{
    internal class RaidExpansionConfiguration : IEntityTypeConfiguration<RaidExpansion>
    {
        public void Configure(EntityTypeBuilder<RaidExpansion> builder)
        {
            builder
                .HasMany(r => r.RaidLocations)
                .WithOne(x => x.Expansion)
                .HasForeignKey(x => x.RaidExpansionId)
                .OnDelete(DeleteBehavior.NoAction);
                
        }
    }
}
