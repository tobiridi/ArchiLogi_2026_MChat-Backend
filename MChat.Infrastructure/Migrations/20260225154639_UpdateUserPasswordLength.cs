using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MChat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserPasswordLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b5966f3-fb3b-4e62-ad72-c3e05735651b"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(84)",
                maxLength: 84,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "LastUpdate", "Password", "Username" },
                values: new object[] { new Guid("fdb45575-e04b-474b-8272-3b210e0b24f9"), new DateOnly(2026, 2, 25), null, new DateTime(2026, 2, 25, 15, 46, 38, 783, DateTimeKind.Utc).AddTicks(7232), "", "old member" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fdb45575-e04b-474b-8272-3b210e0b24f9"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(84)",
                oldMaxLength: 84);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "LastUpdate", "Password", "Username" },
                values: new object[] { new Guid("3b5966f3-fb3b-4e62-ad72-c3e05735651b"), new DateOnly(2026, 2, 20), null, new DateTime(2026, 2, 20, 18, 28, 23, 765, DateTimeKind.Utc).AddTicks(199), "", "old member" });
        }
    }
}
