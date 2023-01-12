using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuildManagerDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class classesspecsseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterClasses_ClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSpecializations_CharacterClasses_ClassId",
                table: "ClassSpecializations");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "ClassSpecializations",
                newName: "CharacterClassId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSpecializations_ClassId",
                table: "ClassSpecializations",
                newName: "IX_ClassSpecializations_CharacterClassId");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ClassSpecializations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClassSpecializationId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ItemLevel",
                table: "Characters",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "CharacterClasses",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "deathknight.png", "Death knight" },
                    { 2, "demonhunter.jpg", "Demon hunter" },
                    { 3, "druid.png", "Druid" },
                    { 4, "evoker.jpg", "Evoker" },
                    { 5, "hunter.png", "Hunter" },
                    { 6, "mage.png", "Mage" },
                    { 7, "monk.png", "Monk" },
                    { 8, "paladin.png", "Paladin" },
                    { 9, "priest.png", "Priest" },
                    { 10, "rogue.png", "Rogue" },
                    { 11, "shaman.png", "Shaman" },
                    { 12, "warlock.png", "Warlock" },
                    { 13, "warrior.png", "warrior" }
                });

            migrationBuilder.InsertData(
                table: "ClassSpecializations",
                columns: new[] { "Id", "CharacterClassId", "ImageUrl", "Name", "Role" },
                values: new object[,]
                {
                    { 1, 1, "deathknight/blood.png", "Blood", 0 },
                    { 2, 1, "deathknight/frost.png", "Frost", 3 },
                    { 3, 1, "deathknight/unholy.png", "Unholy", 3 },
                    { 4, 2, "demonhunter/havoc.jpg", "Havoc", 3 },
                    { 5, 2, "demonhunter/vengeance.jpg", "Vengeance", 0 },
                    { 6, 3, "druid/balance.png", "Balance", 2 },
                    { 7, 3, "druid/feral.png", "Feral", 3 },
                    { 8, 3, "druid/guardian.png", "Guardian", 0 },
                    { 9, 3, "druid/restoration.png", "Restoration", 1 },
                    { 10, 4, "evoker/devastation.jpg", "Devastation", 2 },
                    { 11, 4, "evoker/preservation.jpg", "Preservation", 1 },
                    { 12, 5, "hunter/beastmastery.png", "Beast Mastery", 2 },
                    { 13, 5, "hunter/marksmanship.png", "Marksmanship", 2 },
                    { 14, 5, "hunter/survival.png", "Survival", 3 },
                    { 15, 6, "mage/arcane.png", "Arcane", 2 },
                    { 16, 6, "mage/fire.png", "Fire", 2 },
                    { 17, 6, "mage/frost.png", "Frost", 2 },
                    { 18, 7, "monk/brewmaster.png", "Brewmaster", 0 },
                    { 19, 7, "monk/mistweaver.png", "Mistweaver", 1 },
                    { 20, 7, "monk/windwalker.png", "Windwalker", 3 },
                    { 21, 8, "paladin/holy.png", "Holy", 1 },
                    { 22, 8, "paladin/protection.png", "Protection", 0 },
                    { 23, 8, "paladin/retribution.png", "Retribution", 3 },
                    { 24, 9, "priest/discipline.png", "Discipline", 1 },
                    { 25, 9, "priest/holy.png", "Holy", 1 },
                    { 26, 9, "priest/shadow.png", "Shadow", 2 },
                    { 27, 10, "rogue/assassination.png", "Assassination", 3 },
                    { 28, 10, "rogue/combat.png", "Outlaw", 3 },
                    { 29, 10, "rogue/subtlety.png", "Subtlety", 3 },
                    { 30, 11, "shaman/elemental.png", "Elemental", 2 },
                    { 31, 11, "shaman/enhancement.png", "Enhancement", 3 },
                    { 32, 11, "shaman/restoration.png", "Restoration", 1 },
                    { 33, 12, "warlock/affliction.png", "Affliction", 2 },
                    { 34, 12, "warlock/demonology.png", "Demonology", 2 },
                    { 35, 12, "warlock/destruction.png", "Destruction", 2 },
                    { 36, 13, "warrior/arms.png", "Arms", 3 },
                    { 37, 13, "warrior/fury.png", "Fury", 3 },
                    { 38, 13, "warrior/protection.png", "Protection", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassSpecializationId",
                table: "Characters",
                column: "ClassSpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterClasses_ClassId",
                table: "Characters",
                column: "ClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_ClassSpecializations_ClassSpecializationId",
                table: "Characters",
                column: "ClassSpecializationId",
                principalTable: "ClassSpecializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSpecializations_CharacterClasses_CharacterClassId",
                table: "ClassSpecializations",
                column: "CharacterClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterClasses_ClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_ClassSpecializations_ClassSpecializationId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSpecializations_CharacterClasses_CharacterClassId",
                table: "ClassSpecializations");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ClassSpecializationId",
                table: "Characters");

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ClassSpecializations",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ClassSpecializations");

            migrationBuilder.DropColumn(
                name: "ClassSpecializationId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ItemLevel",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "CharacterClassId",
                table: "ClassSpecializations",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSpecializations_CharacterClassId",
                table: "ClassSpecializations",
                newName: "IX_ClassSpecializations_ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterClasses_ClassId",
                table: "Characters",
                column: "ClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSpecializations_CharacterClasses_ClassId",
                table: "ClassSpecializations",
                column: "ClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
