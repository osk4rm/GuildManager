using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildManagerDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class eventcreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "RaidEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RaidEvents_CreatedById",
                table: "RaidEvents",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_RaidEvents_Users_CreatedById",
                table: "RaidEvents",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaidEvents_Users_CreatedById",
                table: "RaidEvents");

            migrationBuilder.DropIndex(
                name: "IX_RaidEvents_CreatedById",
                table: "RaidEvents");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "RaidEvents");
        }
    }
}
