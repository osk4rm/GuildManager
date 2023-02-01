using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildManagerDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removeddefaultenumvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AcceptanceStatus",
                table: "RaidEventCharacter",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AcceptanceStatus",
                table: "RaidEventCharacter",
                type: "int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
