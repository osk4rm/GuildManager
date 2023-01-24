using GuildManager_DataAccess.Entities;
using GuildManager_DataAccess.Entities.Characters.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_DataAccess.Seeders
{
    public class CharacterClassesSeeder : ISeeder<CharacterClass>
    {
        public IEnumerable<CharacterClass> GetSeedData()
        {
            return new[]
            {
                new CharacterClass{
                    Name= "Death knight",
                    ImageUrl = "deathknight.png",
                    ClassSpecializations = new List<ClassSpecialization>()
                    {
                        new ClassSpecialization
                        {
                            Name = "Blood",
                            Role = ClassSpecializationRole.Tank,
                            ImageUrl = "deathknight/blood.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Frost",
                            Role = ClassSpecializationRole.Melee_DPS,
                            ImageUrl = "deathknight/frost.png"
                        },
                        new ClassSpecialization
                        {
                            Id = 3,
                            Name = "Unholy",
                            CharacterClassId = 1,
                            Role = ClassSpecializationRole.Melee_DPS,
                            ImageUrl = "deathknight/unholy.png"
                        },
                    }

                },
                new CharacterClass{
                    Name= "Demon hunter",
                    ImageUrl = "demonhunter.jpg",
                    ClassSpecializations = new List<ClassSpecialization>()
                    {
                        new ClassSpecialization
                        {
                            Name = "Havoc",
                            Role = ClassSpecializationRole.Melee_DPS,
                            ImageUrl = "demonhunter/havoc.jpg"
                        },
                        new ClassSpecialization
                        {
                            Name = "Vengeance",
                            Role = ClassSpecializationRole.Tank,
                            ImageUrl = "demonhunter/vengeance.jpg"
                        }
                    }
                },
                new CharacterClass{
                    Name= "Druid",
                    ImageUrl = "druid.png",
                    ClassSpecializations = new List<ClassSpecialization>()
                    {
                        new ClassSpecialization
                           {
                                Name = "Balance",
                                Role = ClassSpecializationRole.Ranged_DPS,
                                ImageUrl = "druid/balance.png"
                            },
                            new ClassSpecialization
                            {
                                Name = "Feral",
                                Role = ClassSpecializationRole.Melee_DPS,
                                ImageUrl = "druid/feral.png"
                            },
                            new ClassSpecialization
                            {
                                Name = "Guardian",
                                Role = ClassSpecializationRole.Tank,
                                ImageUrl = "druid/guardian.png"
                            },
                            new ClassSpecialization
                            {
                                Name = "Restoration",
                                Role = ClassSpecializationRole.Healer,
                                ImageUrl = "druid/restoration.png"
                            },
                    }
                },
                new CharacterClass{
                    Name= "Evoker",
                    ImageUrl = "evoker.jpg",
                    ClassSpecializations = new List<ClassSpecialization>()
                    {
                        new ClassSpecialization
                        {
                            Name = "Devastation",
                            Role = ClassSpecializationRole.Ranged_DPS,
                            ImageUrl = "evoker/devastation.jpg"
                        },
                        new ClassSpecialization
                        {
                            Name = "Preservation",
                            Role = ClassSpecializationRole.Healer,
                            ImageUrl = "evoker/preservation.jpg"
                        },
                    }
                },
                new CharacterClass{
                    Name= "Hunter",
                    ImageUrl = "hunter.png",
                    ClassSpecializations = new List<ClassSpecialization>()
                    {
                        new ClassSpecialization
                        {
                            Name = "Beast Mastery",
                            Role = ClassSpecializationRole.Ranged_DPS,
                            ImageUrl = "hunter/beastmastery.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Marksmanship",
                            Role = ClassSpecializationRole.Ranged_DPS,
                            ImageUrl = "hunter/marksmanship.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Survival",
                            Role = ClassSpecializationRole.Melee_DPS,
                            ImageUrl = "hunter/survival.png"
                        },
                    }
                },
                new CharacterClass{
                    Name= "Mage",
                    ImageUrl = "mage.png",
                    ClassSpecializations = new List<ClassSpecialization>()
                    {
                        new ClassSpecialization
                        {
                            Name = "Arcane",
                            Role = ClassSpecializationRole.Ranged_DPS,
                            ImageUrl = "mage/arcane.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Fire",
                            Role = ClassSpecializationRole.Ranged_DPS,
                            ImageUrl = "mage/fire.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Frost",
                            Role = ClassSpecializationRole.Ranged_DPS,
                            ImageUrl = "mage/frost.png"
                        },
                    }
                },
                new CharacterClass{
                    Name= "Monk",
                    ImageUrl = "monk.png",
                    ClassSpecializations = new List<ClassSpecialization>()
                    {
                        new ClassSpecialization
                        {
                            Name = "Brewmaster",
                            Role = ClassSpecializationRole.Tank,
                            ImageUrl = "monk/brewmaster.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Mistweaver",
                            Role = ClassSpecializationRole.Healer,
                            ImageUrl = "monk/mistweaver.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Windwalker",
                            Role = ClassSpecializationRole.Melee_DPS,
                            ImageUrl = "monk/windwalker.png"
                        },
                    }
                },
                new CharacterClass{
                    Name= "Paladin",
                    ImageUrl = "paladin.png",
                    ClassSpecializations = new List<ClassSpecialization>()
                    {
                        new ClassSpecialization
                        {
                            Name = "Holy",
                            Role = ClassSpecializationRole.Healer,
                            ImageUrl = "paladin/holy.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Protection",
                            Role = ClassSpecializationRole.Tank,
                            ImageUrl = "paladin/protection.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Retribution",
                            Role = ClassSpecializationRole.Melee_DPS,
                            ImageUrl = "paladin/retribution.png"
                        },
                    }
                },
                new CharacterClass{
                    Name= "Priest",
                    ImageUrl = "priest.png",
                    ClassSpecializations = new List<ClassSpecialization>()
                    {
                        new ClassSpecialization
                        {
                            Name = "Discipline",
                            Role = ClassSpecializationRole.Healer,
                            ImageUrl = "priest/discipline.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Holy",
                            Role = ClassSpecializationRole.Healer,
                            ImageUrl = "priest/holy.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Shadow",
                            Role = ClassSpecializationRole.Ranged_DPS,
                            ImageUrl = "priest/shadow.png"
                        },
                    }
                },
                new CharacterClass{
                    Name= "Rogue",
                    ImageUrl = "rogue.png",
                    ClassSpecializations = new List<ClassSpecialization>()
                    {
                        new ClassSpecialization
                        {
                            Name = "Assassination",
                            Role = ClassSpecializationRole.Melee_DPS,
                            ImageUrl = "rogue/assassination.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Outlaw",
                            Role = ClassSpecializationRole.Melee_DPS,
                            ImageUrl = "rogue/combat.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Subtlety",
                            Role = ClassSpecializationRole.Melee_DPS,
                            ImageUrl = "rogue/subtlety.png"
                        },
                    }
                },
                new CharacterClass{
                    Name= "Shaman",
                    ImageUrl = "shaman.png",
                    ClassSpecializations = new List<ClassSpecialization>()
                    {
                        new ClassSpecialization
                        {
                            Name = "Elemental",
                            Role = ClassSpecializationRole.Ranged_DPS,
                            ImageUrl = "shaman/elemental.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Enhancement",
                            Role = ClassSpecializationRole.Melee_DPS,
                            ImageUrl = "shaman/enhancement.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Restoration",
                            Role = ClassSpecializationRole.Healer,
                            ImageUrl = "shaman/restoration.png"
                        },
                    }
                },
                new CharacterClass{
                    Name= "Warlock",
                    ImageUrl = "warlock.png",
                    ClassSpecializations = new List<ClassSpecialization>()
                    {
                        new ClassSpecialization
                        {
                            Name = "Affliction",
                            Role = ClassSpecializationRole.Ranged_DPS,
                            ImageUrl = "warlock/affliction.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Demonology",
                            Role = ClassSpecializationRole.Ranged_DPS,
                            ImageUrl = "warlock/demonology.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Destruction",
                            Role = ClassSpecializationRole.Ranged_DPS,
                            ImageUrl = "warlock/destruction.png"
                        },
                    }
                },
                new CharacterClass{
                    Name= "Warrior",
                    ImageUrl = "warrior.png",
                    ClassSpecializations = new List<ClassSpecialization>()
                    {
                        new ClassSpecialization
                        {
                            Name = "Arms",
                            Role = ClassSpecializationRole.Melee_DPS,
                            ImageUrl = "warrior/arms.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Fury",
                            Role = ClassSpecializationRole.Melee_DPS,
                            ImageUrl = "warrior/fury.png"
                        },
                        new ClassSpecialization
                        {
                            Name = "Protection",
                            Role = ClassSpecializationRole.Tank,
                            ImageUrl = "warrior/protection.png"
                        },
                    }
                },
            };
        }
    }
}
