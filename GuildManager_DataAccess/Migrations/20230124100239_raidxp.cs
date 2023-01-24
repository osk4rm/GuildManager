using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuildManagerDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class raidxp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaidLocations_RaidExpansions_RaidExpansionId1",
                table: "RaidLocations");

            migrationBuilder.DropIndex(
                name: "IX_RaidLocations_RaidExpansionId1",
                table: "RaidLocations");

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "RaidLocations",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DropColumn(
                name: "RaidDifficulty",
                table: "RaidLocations");

            migrationBuilder.DropColumn(
                name: "RaidExpansionId1",
                table: "RaidLocations");

            migrationBuilder.AddColumn<int>(
                name: "RaidDifficulty",
                table: "RaidEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RaidDifficulty",
                table: "RaidEvents");

            migrationBuilder.AddColumn<int>(
                name: "RaidDifficulty",
                table: "RaidLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RaidExpansionId1",
                table: "RaidLocations",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "RaidLocations",
                columns: new[] { "Id", "ImageUrl", "Name", "RaidExpansionId", "RaidExpansionId1" },
                values: new object[,]
                {
                    { 1, "raids/1.png", "Blackwing Lair", 1, null },
                    { 2, "raids/2.png", "Molten Core", 1, null },
                    { 3, "raids/3.png", "Onyxia's Lair", 1, null },
                    { 4, "raids/4.png", "Zul'Gurub", 1, null },
                    { 5, "raids/5.png", "Aq40", 1, null },
                    { 6, "raids/6.png", "Karazhan", 2, null },
                    { 7, "raids/7.png", "Gruul's Lair", 2, null },
                    { 8, "raids/8.png", "Magtheridon's Lair", 2, null },
                    { 9, "raids/9.png", "Serpentshrine Cavern", 2, null },
                    { 10, "raids/10.png", "Tempest Keep: The Eye", 2, null },
                    { 11, "raids/11.png", "Black Temple", 2, null },
                    { 12, "raids/12.png", "Hyjal Summit", 2, null },
                    { 13, "raids/13.png", "Sunwell Plateau", 2, null },
                    { 14, "raids/14.png", "Naxxramas", 3, null },
                    { 15, "raids/15.png", "Ulduar", 3, null },
                    { 16, "raids/16.png", "Trial of the Crusader", 3, null },
                    { 17, "raids/17.png", "Icecrown Citadel", 3, null },
                    { 18, "raids/18.png", "Firelands", 4, null },
                    { 19, "raids/19.png", "Dragon Soul", 4, null },
                    { 20, "raids/20.png", "Baradin Hold", 4, null },
                    { 21, "raids/21.png", "Blackwing Descent", 4, null },
                    { 22, "raids/22.png", "Throne of the Four Winds", 4, null },
                    { 23, "raids/23.png", "Mogu'shan Vaults", 5, null },
                    { 24, "raids/24.png", "Heart of Fear", 5, null },
                    { 25, "raids/25.png", "Terrace of Endless Spring", 5, null },
                    { 26, "raids/26.png", "Highmaul", 6, null },
                    { 27, "raids/27.png", "Blackrock Foundry", 6, null },
                    { 28, "raids/28.png", "Hellfire Citadel", 6, null },
                    { 29, "raids/29.png", "The Emerald Nightmare", 7, null },
                    { 30, "raids/30.png", "Trial of Valor", 7, null },
                    { 31, "raids/31.png", "The Nighthold", 7, null },
                    { 32, "raids/32.png", "Tomb of Sargeras", 7, null },
                    { 33, "raids/33.png", "Antorus, the Burning Throne", 7, null },
                    { 34, "raids/34.png", "Uldir", 8, null },
                    { 35, "raids/35.png", "Battle of Dazar'alor", 8, null },
                    { 36, "raids/36.png", "Crucible of Storms", 8, null },
                    { 37, "raids/37.png", "The Eternal Palace", 8, null },
                    { 38, "raids/38.png", "Ny'alotha, the Waking City", 8, null },
                    { 39, "raids/39.png", "Castle Nathria", 9, null },
                    { 40, "raids/40.png", "Sanctum of Domination", 9, null },
                    { 41, "raids/41.png", "Sepulcher of the First Ones", 9, null },
                    { 42, "raids/42.png", "Vault of the Incarnates", 10, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaidLocations_RaidExpansionId1",
                table: "RaidLocations",
                column: "RaidExpansionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RaidLocations_RaidExpansions_RaidExpansionId1",
                table: "RaidLocations",
                column: "RaidExpansionId1",
                principalTable: "RaidExpansions",
                principalColumn: "Id");
        }
    }
}
