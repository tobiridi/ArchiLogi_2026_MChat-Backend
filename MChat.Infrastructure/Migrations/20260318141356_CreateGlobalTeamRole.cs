using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MChat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateGlobalTeamRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d0ee369a-f04b-40d3-9180-8e3cacc596a5"));

            migrationBuilder.CreateTable(
                name: "Global_Teams_Roles",
                columns: table => new
                {
                    global_role_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Global_Teams_Roles", x => x.global_role_name);
                });

            migrationBuilder.CreateTable(
                name: "GlobalTeamRolePermission",
                columns: table => new
                {
                    PermissionName = table.Column<string>(type: "varchar(100)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalTeamRolePermission", x => new { x.PermissionName, x.RoleName });
                    table.ForeignKey(
                        name: "FK_GlobalTeamRolePermission_Global_Teams_Roles_RoleName",
                        column: x => x.RoleName,
                        principalTable: "Global_Teams_Roles",
                        principalColumn: "global_role_name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlobalTeamRolePermission_Teams_Roles_Permissions_PermissionName",
                        column: x => x.PermissionName,
                        principalTable: "Teams_Roles_Permissions",
                        principalColumn: "perm_name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "LastUpdate", "Password", "Username" },
                values: new object[] { new Guid("9aa1e255-8d4f-4b43-b606-8b6e0f227440"), new DateOnly(2026, 3, 18), null, new DateTime(2026, 3, 18, 14, 13, 56, 47, DateTimeKind.Utc).AddTicks(8550), "", "old member" });

            migrationBuilder.CreateIndex(
                name: "IX_GlobalTeamRolePermission_RoleName",
                table: "GlobalTeamRolePermission",
                column: "RoleName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlobalTeamRolePermission");

            migrationBuilder.DropTable(
                name: "Global_Teams_Roles");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9aa1e255-8d4f-4b43-b606-8b6e0f227440"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "LastUpdate", "Password", "Username" },
                values: new object[] { new Guid("d0ee369a-f04b-40d3-9180-8e3cacc596a5"), new DateOnly(2026, 3, 17), null, new DateTime(2026, 3, 17, 20, 53, 1, 525, DateTimeKind.Utc).AddTicks(6287), "", "old member" });
        }
    }
}
