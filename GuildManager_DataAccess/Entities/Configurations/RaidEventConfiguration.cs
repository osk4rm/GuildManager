﻿using GuildManager_DataAccess.Entities.Raids;
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
                .HasOne(r=>r.CreatedBy)
                .WithMany()
                .HasForeignKey(r=>r.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(r=>r.Comments)
                .WithOne(c=>c.RaidEvent)
                .HasForeignKey(c=>c.RaidEventId)
                .OnDelete(DeleteBehavior.ClientCascade);

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
                        //ef resets the value if it's set to default, wtf
                        //rec.Property(x => x.AcceptanceStatus).HasDefaultValue(AcceptanceStatus.Waiting);
                    });
        }
    }
}
