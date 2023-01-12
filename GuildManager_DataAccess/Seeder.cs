using GuildManager_DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess
{
    internal class Seeder
    {
        public static IEnumerable<UserRole> DefaultUserRoles()
        {
            return new[]
            {
                new UserRole{
                    Id = 1,
                    Name= "Admin",
                },
                new UserRole{
                    Id = 2,
                    Name= "Member",
                },
                new UserRole{
                    Id = 3,
                    Name= "Officer",
                },
            };
        }

        public static IEnumerable<CharacterClass> DefaultCharacterClasses()
        {
            return new[]
            {
                new CharacterClass{
                    Id = 1,
                    Name= "Death knight",
                    ImageUrl = "deathknight.png"
                },
                new CharacterClass{
                    Id = 2,
                    Name= "Demon hunter",
                    ImageUrl = "demonhunter.jpg"
                },
                new CharacterClass{
                    Id = 3,
                    Name= "Druid",
                    ImageUrl = "druid.png"
                },
                new CharacterClass{
                    Id = 4,
                    Name= "Evoker",
                    ImageUrl = "evoker.jpg"
                },
                new CharacterClass{
                    Id = 5,
                    Name= "Hunter",
                    ImageUrl = "hunter.png"
                },
                new CharacterClass{
                    Id = 6,
                    Name= "Mage",
                    ImageUrl = "mage.png"
                },
                new CharacterClass{
                    Id = 7,
                    Name= "Monk",
                    ImageUrl = "monk.png"
                },
                new CharacterClass{
                    Id = 8,
                    Name= "Paladin",
                    ImageUrl = "paladin.png"
                },
                new CharacterClass{
                    Id = 9,
                    Name= "Priest",
                    ImageUrl = "priest.png"
                },
                new CharacterClass{
                    Id = 10,
                    Name= "Rogue",
                    ImageUrl = "rogue.png"
                },
                new CharacterClass{
                    Id = 11,
                    Name= "Shaman",
                    ImageUrl = "shaman.png"
                },
                new CharacterClass{
                    Id = 12,
                    Name= "Warlock",
                    ImageUrl = "warlock.png"
                },
                new CharacterClass{
                    Id = 13,
                    Name= "warrior",
                    ImageUrl = "warrior.png"
                },
            };
        }

        public static IEnumerable<ClassSpecialization> DefaultClassSpecs()
        {
            return new[]
            {
                new ClassSpecialization
                {
                    Id = 1,
                    Name = "Blood",
                    ClassId = 1
                },
            };
        }

    }
}
