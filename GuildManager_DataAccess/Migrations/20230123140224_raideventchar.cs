using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildManagerDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class raideventchar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_RaidEvents_RaidEventId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_RaidEventId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "RaidEventId",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "Expansion",
                table: "RaidLocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RaidEventCharacter",
                columns: table => new
                {
                    RaidEventId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    AcceptanceStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 2)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaidEventCharacter", x => new { x.CharacterId, x.RaidEventId });
                    table.ForeignKey(
                        name: "FK_RaidEventCharacter_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaidEventCharacter_RaidEvents_RaidEventId",
                        column: x => x.RaidEventId,
                        principalTable: "RaidEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaidEventCharacter_RaidEventId",
                table: "RaidEventCharacter",
                column: "RaidEventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaidEventCharacter");

            migrationBuilder.DropColumn(
                name: "Expansion",
                table: "RaidLocations");

            migrationBuilder.AddColumn<int>(
                name: "RaidEventId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_RaidEventId",
                table: "Characters",
                column: "RaidEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_RaidEvents_RaidEventId",
                table: "Characters",
                column: "RaidEventId",
                principalTable: "RaidEvents",
                principalColumn: "Id");
        }
    }
}
