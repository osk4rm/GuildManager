using GuildManager_DataAccess.Entities.Raids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Entities.Configurations
{
    public class CommentsConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(c => c.RaidEvent)
                .WithMany(e => e.Comments)
                .HasForeignKey(c => c.RaidEventId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Author)
                .WithMany()
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(c => c.CreatedDate)
                .HasDefaultValueSql("getutcdate()");
        }
    }
}
