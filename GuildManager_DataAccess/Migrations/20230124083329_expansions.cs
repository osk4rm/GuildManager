using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildManagerDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class expansions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaidLocations_RaidExpansion_ExpansionId",
                table: "RaidLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_RaidLocations_RaidExpansion_RaidExpansionId",
                table: "RaidLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaidExpansion",
                table: "RaidExpansion");

            migrationBuilder.RenameTable(
                name: "RaidExpansion",
                newName: "RaidExpansions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaidExpansions",
                table: "RaidExpansions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RaidLocations_RaidExpansions_ExpansionId",
                table: "RaidLocations",
                column: "ExpansionId",
                principalTable: "RaidExpansions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RaidLocations_RaidExpansions_RaidExpansionId",
                table: "RaidLocations",
                column: "RaidExpansionId",
                principalTable: "RaidExpansions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaidLocations_RaidExpansions_ExpansionId",
                table: "RaidLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_RaidLocations_RaidExpansions_RaidExpansionId",
                table: "RaidLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaidExpansions",
                table: "RaidExpansions");

            migrationBuilder.RenameTable(
                name: "RaidExpansions",
                newName: "RaidExpansion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaidExpansion",
                table: "RaidExpansion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RaidLocations_RaidExpansion_ExpansionId",
                table: "RaidLocations",
                column: "ExpansionId",
                principalTable: "RaidExpansion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RaidLocations_RaidExpansion_RaidExpansionId",
                table: "RaidLocations",
                column: "RaidExpansionId",
                principalTable: "RaidExpansion",
                principalColumn: "Id");
        }
    }
}
