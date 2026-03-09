using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MChat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JWTRefreshTokenIntegration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fdb45575-e04b-474b-8272-3b210e0b24f9"));

            migrationBuilder.CreateTable(
                name: "UsersRefreshToken",
                columns: table => new
                {
                    RefreshToken = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRefreshToken", x => x.RefreshToken);
                    table.ForeignKey(
                        name: "FK_UsersRefreshToken_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "LastUpdate", "Password", "Username" },
                values: new object[] { new Guid("44362eb9-c451-4de3-8509-a3d62711de77"), new DateOnly(2026, 3, 7), null, new DateTime(2026, 3, 7, 13, 38, 24, 121, DateTimeKind.Utc).AddTicks(6394), "", "old member" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRefreshToken_UserId",
                table: "UsersRefreshToken",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRefreshToken");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44362eb9-c451-4de3-8509-a3d62711de77"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "LastUpdate", "Password", "Username" },
                values: new object[] { new Guid("fdb45575-e04b-474b-8272-3b210e0b24f9"), new DateOnly(2026, 2, 25), null, new DateTime(2026, 2, 25, 15, 46, 38, 783, DateTimeKind.Utc).AddTicks(7232), "", "old member" });
        }
    }
}
