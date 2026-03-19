using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MChat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameFKTeamChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Creator",
                table: "Teams",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_Id_Creator",
                table: "Teams",
                newName: "IX_Teams_CreatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Teams",
                newName: "Id_Creator");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_CreatorId",
                table: "Teams",
                newName: "IX_Teams_Id_Creator");
        }
    }
}
