using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Entities.Configurations
{
    internal class ClassSpecConfiguration : IEntityTypeConfiguration<ClassSpecialization>
    {
        public void Configure(EntityTypeBuilder<ClassSpecialization> builder)
        {
            builder.HasData(Seeder.DefaultClassSpecs());
            

            builder
                .HasOne(s => s.CharacterClass)
                .WithMany(c => c.ClassSpecializations)
                .HasForeignKey(s => s.CharacterClassId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
