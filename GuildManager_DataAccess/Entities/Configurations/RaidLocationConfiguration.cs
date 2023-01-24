using GuildManager_DataAccess.Entities.Raids;
using GuildManager_DataAccess.Enum;
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
    public class RaidLocationConfiguration : IEntityTypeConfiguration<RaidLocation>
    {
        public void Configure(EntityTypeBuilder<RaidLocation> builder)
        {
            builder
                .HasOne(l => l.Expansion)
                .WithMany(x => x.RaidLocations)
                .HasForeignKey(l => l.RaidExpansionId)
                .OnDelete(DeleteBehavior.ClientCascade);

            

            builder
                .Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
