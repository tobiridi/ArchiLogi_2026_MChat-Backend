using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MChat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "LastUpdate", "Password", "Username" },
                values: new object[] { new Guid("3b5966f3-fb3b-4e62-ad72-c3e05735651b"), new DateOnly(2026, 2, 20), null, new DateTime(2026, 2, 20, 18, 28, 23, 765, DateTimeKind.Utc).AddTicks(199), "", "old member" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b5966f3-fb3b-4e62-ad72-c3e05735651b"));
        }
    }
}
