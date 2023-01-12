using GuildManager_DataAccess.Entities;
using GuildManager_DataAccess.Entities.Characters.Enum;
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
                    CharacterClassId = 1,
                    Role = ClassSpecializationRole.Tank,
                    ImageUrl = "deathknight/blood.png"
                },
                new ClassSpecialization
                {
                    Id = 2,
                    Name = "Frost",
                    CharacterClassId = 1,
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
                new ClassSpecialization
                {
                    Id = 4,
                    Name = "Havoc",
                    CharacterClassId = 2,
                    Role = ClassSpecializationRole.Melee_DPS,
                    ImageUrl = "demonhunter/havoc.jpg"
                },
                new ClassSpecialization
                {
                    Id = 5,
                    Name = "Vengeance",
                    CharacterClassId = 2,
                    Role = ClassSpecializationRole.Tank,
                    ImageUrl = "demonhunter/vengeance.jpg"
                },
                new ClassSpecialization
                {
                    Id = 6,
                    Name = "Balance",
                    CharacterClassId = 3,
                    Role = ClassSpecializationRole.Ranged_DPS,
                    ImageUrl = "druid/balance.png"
                },
                new ClassSpecialization
                {
                    Id = 7,
                    Name = "Feral",
                    CharacterClassId = 3,
                    Role = ClassSpecializationRole.Melee_DPS,
                    ImageUrl = "druid/feral.png"
                },
                new ClassSpecialization
                {
                    Id = 8,
                    Name = "Guardian",
                    CharacterClassId = 3,
                    Role = ClassSpecializationRole.Tank,
                    ImageUrl = "druid/guardian.png"
                },
                new ClassSpecialization
                {
                    Id = 9,
                    Name = "Restoration",
                    CharacterClassId = 3,
                    Role = ClassSpecializationRole.Healer,
                    ImageUrl = "druid/restoration.png"
                },
                new ClassSpecialization
                {
                    Id = 10,
                    Name = "Devastation",
                    CharacterClassId = 4,
                    Role = ClassSpecializationRole.Ranged_DPS,
                    ImageUrl = "evoker/devastation.jpg"
                },
                new ClassSpecialization
                {
                    Id = 11,
                    Name = "Preservation",
                    CharacterClassId = 4,
                    Role = ClassSpecializationRole.Healer,
                    ImageUrl = "evoker/preservation.jpg"
                },
                new ClassSpecialization
                {
                    Id = 12,
                    Name = "Beast Mastery",
                    CharacterClassId = 5,
                    Role = ClassSpecializationRole.Ranged_DPS,
                    ImageUrl = "hunter/beastmastery.png"
                },
                new ClassSpecialization
                {
                    Id = 13,
                    Name = "Marksmanship",
                    CharacterClassId = 5,
                    Role = ClassSpecializationRole.Ranged_DPS,
                    ImageUrl = "hunter/marksmanship.png"
                },
                new ClassSpecialization
                {
                    Id = 14,
                    Name = "Survival",
                    CharacterClassId = 5,
                    Role = ClassSpecializationRole.Melee_DPS,
                    ImageUrl = "hunter/survival.png"
                },
                new ClassSpecialization
                {
                    Id = 15,
                    Name = "Arcane",
                    CharacterClassId = 6,
                    Role = ClassSpecializationRole.Ranged_DPS,
                    ImageUrl = "mage/arcane.png"
                },
                new ClassSpecialization
                {
                    Id = 16,
                    Name = "Fire",
                    CharacterClassId = 6,
                    Role = ClassSpecializationRole.Ranged_DPS,
                    ImageUrl = "mage/fire.png"
                },
                new ClassSpecialization
                {
                    Id = 17,
                    Name = "Frost",
                    CharacterClassId = 6,
                    Role = ClassSpecializationRole.Ranged_DPS,
                    ImageUrl = "mage/frost.png"
                },
                new ClassSpecialization
                {
                    Id = 18,
                    Name = "Brewmaster",
                    CharacterClassId = 7,
                    Role = ClassSpecializationRole.Tank,
                    ImageUrl = "monk/brewmaster.png"
                },
                new ClassSpecialization
                {
                    Id = 19,
                    Name = "Mistweaver",
                    CharacterClassId = 7,
                    Role = ClassSpecializationRole.Healer,
                    ImageUrl = "monk/mistweaver.png"
                },
                new ClassSpecialization
                {
                    Id = 20,
                    Name = "Windwalker",
                    CharacterClassId = 7,
                    Role = ClassSpecializationRole.Melee_DPS,
                    ImageUrl = "monk/windwalker.png"
                },
                new ClassSpecialization
                {
                    Id = 21,
                    Name = "Holy",
                    CharacterClassId = 8,
                    Role = ClassSpecializationRole.Healer,
                    ImageUrl = "paladin/holy.png"
                },
                new ClassSpecialization
                {
                    Id = 22,
                    Name = "Protection",
                    CharacterClassId = 8,
                    Role = ClassSpecializationRole.Tank,
                    ImageUrl = "paladin/protection.png"
                },
                new ClassSpecialization
                {
                    Id = 23,
                    Name = "Retribution",
                    CharacterClassId = 8,
                    Role = ClassSpecializationRole.Melee_DPS,
                    ImageUrl = "paladin/retribution.png"
                },
                new ClassSpecialization
                {
                    Id = 24,
                    Name = "Discipline",
                    CharacterClassId = 9,
                    Role = ClassSpecializationRole.Healer,
                    ImageUrl = "priest/discipline.png"
                },
                new ClassSpecialization
                {
                    Id = 25,
                    Name = "Holy",
                    CharacterClassId = 9,
                    Role = ClassSpecializationRole.Healer,
                    ImageUrl = "priest/holy.png"
                },
                new ClassSpecialization
                {
                    Id = 26,
                    Name = "Shadow",
                    CharacterClassId = 9,
                    Role = ClassSpecializationRole.Ranged_DPS,
                    ImageUrl = "priest/shadow.png"
                },
                new ClassSpecialization
                {
                    Id = 27,
                    Name = "Assassination",
                    CharacterClassId = 10,
                    Role = ClassSpecializationRole.Melee_DPS,
                    ImageUrl = "rogue/assassination.png"
                },
                new ClassSpecialization
                {
                    Id = 28,
                    Name = "Outlaw",
                    CharacterClassId = 10,
                    Role = ClassSpecializationRole.Melee_DPS,
                    ImageUrl = "rogue/combat.png"
                },
                new ClassSpecialization
                {
                    Id = 29,
                    Name = "Subtlety",
                    CharacterClassId = 10,
                    Role = ClassSpecializationRole.Melee_DPS,
                    ImageUrl = "rogue/subtlety.png"
                },
                new ClassSpecialization
                {
                    Id = 30,
                    Name = "Elemental",
                    CharacterClassId = 11,
                    Role = ClassSpecializationRole.Ranged_DPS,
                    ImageUrl = "shaman/elemental.png"
                },
                new ClassSpecialization
                {
                    Id = 31,
                    Name = "Enhancement",
                    CharacterClassId = 11,
                    Role = ClassSpecializationRole.Melee_DPS,
                    ImageUrl = "shaman/enhancement.png"
                },
                new ClassSpecialization
                {
                    Id = 32,
                    Name = "Restoration",
                    CharacterClassId = 11,
                    Role = ClassSpecializationRole.Healer,
                    ImageUrl = "shaman/restoration.png"
                },
                new ClassSpecialization
                {
                    Id = 33,
                    Name = "Affliction",
                    CharacterClassId = 12,
                    Role = ClassSpecializationRole.Ranged_DPS,
                    ImageUrl = "warlock/affliction.png"
                },
                new ClassSpecialization
                {
                    Id = 34,
                    Name = "Demonology",
                    CharacterClassId = 12,
                    Role = ClassSpecializationRole.Ranged_DPS,
                    ImageUrl = "warlock/demonology.png"
                },
                new ClassSpecialization
                {
                    Id = 35,
                    Name = "Destruction",
                    CharacterClassId = 12,
                    Role = ClassSpecializationRole.Ranged_DPS,
                    ImageUrl = "warlock/destruction.png"
                },
                new ClassSpecialization
                {
                    Id = 36,
                    Name = "Arms",
                    CharacterClassId = 13,
                    Role = ClassSpecializationRole.Melee_DPS,
                    ImageUrl = "warrior/arms.png"
                },
                new ClassSpecialization
                {
                    Id = 37,
                    Name = "Fury",
                    CharacterClassId = 13,
                    Role = ClassSpecializationRole.Melee_DPS,
                    ImageUrl = "warrior/fury.png"
                },
                new ClassSpecialization
                {
                    Id = 38,
                    Name = "Protection",
                    CharacterClassId = 13,
                    Role = ClassSpecializationRole.Tank,
                    ImageUrl = "warrior/protection.png"
                },

            };
        }
    }
}
