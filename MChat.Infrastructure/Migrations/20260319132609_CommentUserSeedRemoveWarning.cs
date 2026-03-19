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
                keyValue: new Guid("d0ee369a-f04b-40d3-9180-8e3cacc596a5"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "LastUpdate", "Password", "Username" },
                values: new object[] { new Guid("d0ee369a-f04b-40d3-9180-8e3cacc596a5"), new DateOnly(2026, 3, 17), null, new DateTime(2026, 3, 17, 20, 53, 1, 525, DateTimeKind.Utc).AddTicks(6287), "", "old member" });
        }
    }
}
