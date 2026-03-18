using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MChat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CommentUserSeedRemoveWarning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9aa1e255-8d4f-4b43-b606-8b6e0f227440"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "LastUpdate", "Password", "Username" },
                values: new object[] { new Guid("9aa1e255-8d4f-4b43-b606-8b6e0f227440"), new DateOnly(2026, 3, 18), null, new DateTime(2026, 3, 18, 14, 13, 56, 47, DateTimeKind.Utc).AddTicks(8550), "", "old member" });
        }
    }
}
