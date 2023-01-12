using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Entities.Configurations
{
    public class CharacterClassConfiguration : IEntityTypeConfiguration<CharacterClass>
    {
        public void Configure(EntityTypeBuilder<CharacterClass> builder)
        {
            builder.HasData(Seeder.DefaultCharacterClasses());
            //builder.HasData(Seeder.DefaultClassesAndSpecs());

            builder
                .HasMany(x => x.ClassSpecializations)
                .WithOne(y => y.CharacterClass)
                .HasForeignKey(x=>x.CharacterClassId);
        }
    }
}
