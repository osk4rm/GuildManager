using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildManagerDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class eventslocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaidEvents_RaidLocations_RaidLocationId",
                table: "RaidEvents");

            migrationBuilder.DropColumn(
                name: "Expansion",
                table: "RaidLocations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RaidLocations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ExpansionId",
                table: "RaidLocations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaidDifficulty",
                table: "RaidLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RaidExpansionId",
                table: "RaidLocations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RaidLocationId",
                table: "RaidEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RaidEvents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "AutoAccept",
                table: "RaidEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RaidExpansion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaidExpansion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaidLocations_ExpansionId",
                table: "RaidLocations",
                column: "ExpansionId");

            migrationBuilder.CreateIndex(
                name: "IX_RaidLocations_RaidExpansionId",
                table: "RaidLocations",
                column: "RaidExpansionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaidEvents_RaidLocations_RaidLocationId",
                table: "RaidEvents",
                column: "RaidLocationId",
                principalTable: "RaidLocations",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaidEvents_RaidLocations_RaidLocationId",
                table: "RaidEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_RaidLocations_RaidExpansion_ExpansionId",
                table: "RaidLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_RaidLocations_RaidExpansion_RaidExpansionId",
                table: "RaidLocations");

            migrationBuilder.DropTable(
                name: "RaidExpansion");

            migrationBuilder.DropIndex(
                name: "IX_RaidLocations_ExpansionId",
                table: "RaidLocations");

            migrationBuilder.DropIndex(
                name: "IX_RaidLocations_RaidExpansionId",
                table: "RaidLocations");

            migrationBuilder.DropColumn(
                name: "ExpansionId",
                table: "RaidLocations");

            migrationBuilder.DropColumn(
                name: "RaidDifficulty",
                table: "RaidLocations");

            migrationBuilder.DropColumn(
                name: "RaidExpansionId",
                table: "RaidLocations");

            migrationBuilder.DropColumn(
                name: "AutoAccept",
                table: "RaidEvents");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RaidLocations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Expansion",
                table: "RaidLocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "RaidLocationId",
                table: "RaidEvents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RaidEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RaidEvents_RaidLocations_RaidLocationId",
                table: "RaidEvents",
                column: "RaidLocationId",
                principalTable: "RaidLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
