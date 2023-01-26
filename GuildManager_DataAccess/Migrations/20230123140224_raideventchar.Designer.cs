﻿// <auto-generated />
using System;
using GuildManager_DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuildManagerDataAccess.Migrations
{
    [DbContext(typeof(GuildManagerDbContext))]
    [Migration("20230123140224_raideventchar")]
    partial class raideventchar
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GuildManager_DataAccess.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("ClassSpecializationId")
                        .HasColumnType("int");

                    b.Property<decimal>("ItemLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("ClassSpecializationId");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.CharacterClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CharacterClasses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "deathknight.png",
                            Name = "Death knight"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "demonhunter.jpg",
                            Name = "Demon hunter"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "druid.png",
                            Name = "Druid"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "evoker.jpg",
                            Name = "Evoker"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "hunter.png",
                            Name = "Hunter"
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = "mage.png",
                            Name = "Mage"
                        },
                        new
                        {
                            Id = 7,
                            ImageUrl = "monk.png",
                            Name = "Monk"
                        },
                        new
                        {
                            Id = 8,
                            ImageUrl = "paladin.png",
                            Name = "Paladin"
                        },
                        new
                        {
                            Id = 9,
                            ImageUrl = "priest.png",
                            Name = "Priest"
                        },
                        new
                        {
                            Id = 10,
                            ImageUrl = "rogue.png",
                            Name = "Rogue"
                        },
                        new
                        {
                            Id = 11,
                            ImageUrl = "shaman.png",
                            Name = "Shaman"
                        },
                        new
                        {
                            Id = 12,
                            ImageUrl = "warlock.png",
                            Name = "Warlock"
                        },
                        new
                        {
                            Id = 13,
                            ImageUrl = "warrior.png",
                            Name = "warrior"
                        });
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.ClassSpecialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterClassId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterClassId");

                    b.ToTable("ClassSpecializations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CharacterClassId = 1,
                            ImageUrl = "deathknight/blood.png",
                            Name = "Blood",
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            CharacterClassId = 1,
                            ImageUrl = "deathknight/frost.png",
                            Name = "Frost",
                            Role = 3
                        },
                        new
                        {
                            Id = 3,
                            CharacterClassId = 1,
                            ImageUrl = "deathknight/unholy.png",
                            Name = "Unholy",
                            Role = 3
                        },
                        new
                        {
                            Id = 4,
                            CharacterClassId = 2,
                            ImageUrl = "demonhunter/havoc.jpg",
                            Name = "Havoc",
                            Role = 3
                        },
                        new
                        {
                            Id = 5,
                            CharacterClassId = 2,
                            ImageUrl = "demonhunter/vengeance.jpg",
                            Name = "Vengeance",
                            Role = 0
                        },
                        new
                        {
                            Id = 6,
                            CharacterClassId = 3,
                            ImageUrl = "druid/balance.png",
                            Name = "Balance",
                            Role = 2
                        },
                        new
                        {
                            Id = 7,
                            CharacterClassId = 3,
                            ImageUrl = "druid/feral.png",
                            Name = "Feral",
                            Role = 3
                        },
                        new
                        {
                            Id = 8,
                            CharacterClassId = 3,
                            ImageUrl = "druid/guardian.png",
                            Name = "Guardian",
                            Role = 0
                        },
                        new
                        {
                            Id = 9,
                            CharacterClassId = 3,
                            ImageUrl = "druid/restoration.png",
                            Name = "Restoration",
                            Role = 1
                        },
                        new
                        {
                            Id = 10,
                            CharacterClassId = 4,
                            ImageUrl = "evoker/devastation.jpg",
                            Name = "Devastation",
                            Role = 2
                        },
                        new
                        {
                            Id = 11,
                            CharacterClassId = 4,
                            ImageUrl = "evoker/preservation.jpg",
                            Name = "Preservation",
                            Role = 1
                        },
                        new
                        {
                            Id = 12,
                            CharacterClassId = 5,
                            ImageUrl = "hunter/beastmastery.png",
                            Name = "Beast Mastery",
                            Role = 2
                        },
                        new
                        {
                            Id = 13,
                            CharacterClassId = 5,
                            ImageUrl = "hunter/marksmanship.png",
                            Name = "Marksmanship",
                            Role = 2
                        },
                        new
                        {
                            Id = 14,
                            CharacterClassId = 5,
                            ImageUrl = "hunter/survival.png",
                            Name = "Survival",
                            Role = 3
                        },
                        new
                        {
                            Id = 15,
                            CharacterClassId = 6,
                            ImageUrl = "mage/arcane.png",
                            Name = "Arcane",
                            Role = 2
                        },
                        new
                        {
                            Id = 16,
                            CharacterClassId = 6,
                            ImageUrl = "mage/fire.png",
                            Name = "Fire",
                            Role = 2
                        },
                        new
                        {
                            Id = 17,
                            CharacterClassId = 6,
                            ImageUrl = "mage/frost.png",
                            Name = "Frost",
                            Role = 2
                        },
                        new
                        {
                            Id = 18,
                            CharacterClassId = 7,
                            ImageUrl = "monk/brewmaster.png",
                            Name = "Brewmaster",
                            Role = 0
                        },
                        new
                        {
                            Id = 19,
                            CharacterClassId = 7,
                            ImageUrl = "monk/mistweaver.png",
                            Name = "Mistweaver",
                            Role = 1
                        },
                        new
                        {
                            Id = 20,
                            CharacterClassId = 7,
                            ImageUrl = "monk/windwalker.png",
                            Name = "Windwalker",
                            Role = 3
                        },
                        new
                        {
                            Id = 21,
                            CharacterClassId = 8,
                            ImageUrl = "paladin/holy.png",
                            Name = "Holy",
                            Role = 1
                        },
                        new
                        {
                            Id = 22,
                            CharacterClassId = 8,
                            ImageUrl = "paladin/protection.png",
                            Name = "Protection",
                            Role = 0
                        },
                        new
                        {
                            Id = 23,
                            CharacterClassId = 8,
                            ImageUrl = "paladin/retribution.png",
                            Name = "Retribution",
                            Role = 3
                        },
                        new
                        {
                            Id = 24,
                            CharacterClassId = 9,
                            ImageUrl = "priest/discipline.png",
                            Name = "Discipline",
                            Role = 1
                        },
                        new
                        {
                            Id = 25,
                            CharacterClassId = 9,
                            ImageUrl = "priest/holy.png",
                            Name = "Holy",
                            Role = 1
                        },
                        new
                        {
                            Id = 26,
                            CharacterClassId = 9,
                            ImageUrl = "priest/shadow.png",
                            Name = "Shadow",
                            Role = 2
                        },
                        new
                        {
                            Id = 27,
                            CharacterClassId = 10,
                            ImageUrl = "rogue/assassination.png",
                            Name = "Assassination",
                            Role = 3
                        },
                        new
                        {
                            Id = 28,
                            CharacterClassId = 10,
                            ImageUrl = "rogue/combat.png",
                            Name = "Outlaw",
                            Role = 3
                        },
                        new
                        {
                            Id = 29,
                            CharacterClassId = 10,
                            ImageUrl = "rogue/subtlety.png",
                            Name = "Subtlety",
                            Role = 3
                        },
                        new
                        {
                            Id = 30,
                            CharacterClassId = 11,
                            ImageUrl = "shaman/elemental.png",
                            Name = "Elemental",
                            Role = 2
                        },
                        new
                        {
                            Id = 31,
                            CharacterClassId = 11,
                            ImageUrl = "shaman/enhancement.png",
                            Name = "Enhancement",
                            Role = 3
                        },
                        new
                        {
                            Id = 32,
                            CharacterClassId = 11,
                            ImageUrl = "shaman/restoration.png",
                            Name = "Restoration",
                            Role = 1
                        },
                        new
                        {
                            Id = 33,
                            CharacterClassId = 12,
                            ImageUrl = "warlock/affliction.png",
                            Name = "Affliction",
                            Role = 2
                        },
                        new
                        {
                            Id = 34,
                            CharacterClassId = 12,
                            ImageUrl = "warlock/demonology.png",
                            Name = "Demonology",
                            Role = 2
                        },
                        new
                        {
                            Id = 35,
                            CharacterClassId = 12,
                            ImageUrl = "warlock/destruction.png",
                            Name = "Destruction",
                            Role = 2
                        },
                        new
                        {
                            Id = 36,
                            CharacterClassId = 13,
                            ImageUrl = "warrior/arms.png",
                            Name = "Arms",
                            Role = 3
                        },
                        new
                        {
                            Id = 37,
                            CharacterClassId = 13,
                            ImageUrl = "warrior/fury.png",
                            Name = "Fury",
                            Role = 3
                        },
                        new
                        {
                            Id = 38,
                            CharacterClassId = 13,
                            ImageUrl = "warrior/protection.png",
                            Name = "Protection",
                            Role = 0
                        });
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.Raids.RaidEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RaidLocationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RaidLocationId");

                    b.ToTable("RaidEvents");
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.Raids.RaidEventCharacter", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("RaidEventId")
                        .HasColumnType("int");

                    b.Property<int>("AcceptanceStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.HasKey("CharacterId", "RaidEventId");

                    b.HasIndex("RaidEventId");

                    b.ToTable("RaidEventCharacter");
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.Raids.RaidLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Expansion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RaidLocations");
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Avatar")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Member"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Officer"
                        });
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.Character", b =>
                {
                    b.HasOne("GuildManager_DataAccess.Entities.CharacterClass", "Class")
                        .WithMany("Characters")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GuildManager_DataAccess.Entities.ClassSpecialization", "MainSpec")
                        .WithMany("Characters")
                        .HasForeignKey("ClassSpecializationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GuildManager_DataAccess.Entities.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("MainSpec");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.ClassSpecialization", b =>
                {
                    b.HasOne("GuildManager_DataAccess.Entities.CharacterClass", "CharacterClass")
                        .WithMany("ClassSpecializations")
                        .HasForeignKey("CharacterClassId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("CharacterClass");
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.Raids.RaidEvent", b =>
                {
                    b.HasOne("GuildManager_DataAccess.Entities.Raids.RaidLocation", "RaidLocation")
                        .WithMany()
                        .HasForeignKey("RaidLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RaidLocation");
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.Raids.RaidEventCharacter", b =>
                {
                    b.HasOne("GuildManager_DataAccess.Entities.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuildManager_DataAccess.Entities.Raids.RaidEvent", "RaidEvent")
                        .WithMany()
                        .HasForeignKey("RaidEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("RaidEvent");
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.User", b =>
                {
                    b.HasOne("GuildManager_DataAccess.Entities.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.CharacterClass", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("ClassSpecializations");
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.ClassSpecialization", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("GuildManager_DataAccess.Entities.User", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}