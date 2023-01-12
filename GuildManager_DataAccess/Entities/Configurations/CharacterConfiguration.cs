using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Entities.Configurations
{
    internal class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder
                .HasOne(ch => ch.Class)
                .WithMany(c => c.Characters)
                .HasForeignKey(ch => ch.ClassId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(ch => ch.MainSpec)
                .WithMany(s => s.Characters)
                .HasForeignKey(ch => ch.ClassSpecializationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
