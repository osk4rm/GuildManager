using GuildManager_DataAccess.Entities.Raids;
using GuildManager_DataAccess.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Entities.Configurations
{
    public class RaidEventConfiguration : IEntityTypeConfiguration<RaidEvent>
    {
        public void Configure(EntityTypeBuilder<RaidEvent> builder)
        {
            builder
                .HasOne(r => r.RaidLocation)
                .WithMany()
                .HasForeignKey(r => r.RaidLocationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(l => l.RaidDifficulty)
                .IsRequired()
                .HasDefaultValue(RaidDifficulty.Normal);

            builder
                .HasMany(r => r.Participants)
                .WithMany(p => p.RaidEvents)
                .UsingEntity<RaidEventCharacter>(
                    r => r.HasOne(rec => rec.Character)
                    .WithMany()
                    .HasForeignKey(rec => rec.CharacterId),

                    r => r.HasOne(rec => rec.RaidEvent)
                    .WithMany()
                    .HasForeignKey(rec => rec.RaidEventId),

                    rec =>
                    {
                        rec.HasKey(x => new { x.CharacterId, x.RaidEventId });
                        rec.Property(x => x.AcceptanceStatus).HasDefaultValue(AcceptanceStatus.Waiting);
                    });
        }
    }
}
