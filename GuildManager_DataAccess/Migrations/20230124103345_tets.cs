using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildManagerDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class tets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaidLocations_RaidExpansions_RaidExpansionId",
                table: "RaidLocations");

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
                name: "FK_RaidLocations_RaidExpansions_RaidExpansionId",
                table: "RaidLocations");

            migrationBuilder.AddForeignKey(
                name: "FK_RaidLocations_RaidExpansions_RaidExpansionId",
                table: "RaidLocations",
                column: "RaidExpansionId",
                principalTable: "RaidExpansions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
