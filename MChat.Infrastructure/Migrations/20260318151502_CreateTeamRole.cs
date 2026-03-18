using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MChat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTeamRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamsRoles",
                columns: table => new
                {
                    TeamRoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id_Teams = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsRoles", x => x.TeamRoleName);
                    table.ForeignKey(
                        name: "FK_TeamsRoles_Teams",
                        column: x => x.Id_Teams,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamRoleTeamRolePermission",
                columns: table => new
                {
                    PermissionName = table.Column<string>(type: "varchar(100)", nullable: false),
                    TeamRoleName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRoleTeamRolePermission", x => new { x.PermissionName, x.TeamRoleName });
                    table.ForeignKey(
                        name: "FK_TeamRoleTeamRolePermission_TeamsRolesPermissions_PermissionName",
                        column: x => x.PermissionName,
                        principalTable: "TeamsRolesPermissions",
                        principalColumn: "perm_name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamRoleTeamRolePermission_TeamsRoles_TeamRoleName",
                        column: x => x.TeamRoleName,
                        principalTable: "TeamsRoles",
                        principalColumn: "TeamRoleName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamRoleTeamRolePermission_TeamRoleName",
                table: "TeamRoleTeamRolePermission",
                column: "TeamRoleName");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsRoles_Id_Teams",
                table: "TeamsRoles",
                column: "Id_Teams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamRoleTeamRolePermission");

            migrationBuilder.DropTable(
                name: "TeamsRoles");
        }
    }
}
