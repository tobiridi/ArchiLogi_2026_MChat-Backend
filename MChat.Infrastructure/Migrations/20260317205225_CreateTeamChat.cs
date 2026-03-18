using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MChat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTeamChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44362eb9-c451-4de3-8509-a3d62711de77"));

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Id_Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Users",
                        column: x => x.Id_Creator,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "LastUpdate", "Password", "Username" },
                values: new object[] { new Guid("7467d4cd-b497-4cc7-95cd-aa882544a8f7"), new DateOnly(2026, 3, 17), null, new DateTime(2026, 3, 17, 20, 52, 25, 21, DateTimeKind.Utc).AddTicks(5131), "", "old member" });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Id_Creator",
                table: "Teams",
                column: "Id_Creator");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7467d4cd-b497-4cc7-95cd-aa882544a8f7"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "LastUpdate", "Password", "Username" },
                values: new object[] { new Guid("44362eb9-c451-4de3-8509-a3d62711de77"), new DateOnly(2026, 3, 7), null, new DateTime(2026, 3, 7, 13, 38, 24, 121, DateTimeKind.Utc).AddTicks(6394), "", "old member" });
        }
    }
}
