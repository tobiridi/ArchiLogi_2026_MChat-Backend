using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MChat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTeamRolePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7467d4cd-b497-4cc7-95cd-aa882544a8f7"));

            migrationBuilder.CreateTable(
                name: "Teams_Roles_Permissions",
                columns: table => new
                {
                    perm_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams_Roles_Permissions", x => x.perm_name);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "LastUpdate", "Password", "Username" },
                values: new object[] { new Guid("d0ee369a-f04b-40d3-9180-8e3cacc596a5"), new DateOnly(2026, 3, 17), null, new DateTime(2026, 3, 17, 20, 53, 1, 525, DateTimeKind.Utc).AddTicks(6287), "", "old member" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams_Roles_Permissions");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d0ee369a-f04b-40d3-9180-8e3cacc596a5"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "LastUpdate", "Password", "Username" },
                values: new object[] { new Guid("7467d4cd-b497-4cc7-95cd-aa882544a8f7"), new DateOnly(2026, 3, 17), null, new DateTime(2026, 3, 17, 20, 52, 25, 21, DateTimeKind.Utc).AddTicks(5131), "", "old member" });
        }
    }
}
