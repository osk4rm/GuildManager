using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildManagerDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class charactersspecsondeletenoaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_ClassSpecializations_ClassSpecializationId",
                table: "Characters");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_ClassSpecializations_ClassSpecializationId",
                table: "Characters",
                column: "ClassSpecializationId",
                principalTable: "ClassSpecializations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_ClassSpecializations_ClassSpecializationId",
                table: "Characters");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_ClassSpecializations_ClassSpecializationId",
                table: "Characters",
                column: "ClassSpecializationId",
                principalTable: "ClassSpecializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
