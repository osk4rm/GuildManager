using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildManagerDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class raidstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "RaidEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "RaidEvents");
        }
    }
}
