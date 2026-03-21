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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamRoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamsRoles_Teams",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamRoleTeamRolePermission",
                columns: table => new
                {
                    PermissionName = table.Column<string>(type: "varchar(100)", nullable: false),
                    TeamRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRoleTeamRolePermission", x => new { x.PermissionName, x.TeamRoleId });
                    table.ForeignKey(
                        name: "FK_TeamRoleTeamRolePermission_TeamsRolesPermissions_PermissionName",
                        column: x => x.PermissionName,
                        principalTable: "TeamsRolesPermissions",
                        principalColumn: "PermissionName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamRoleTeamRolePermission_TeamsRoles_TeamRoleId",
                        column: x => x.TeamRoleId,
                        principalTable: "TeamsRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamRoleTeamRolePermission_TeamRoleId",
                table: "TeamRoleTeamRolePermission",
                column: "TeamRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsRoles_TeamId",
                table: "TeamsRoles",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "UK_TeamsRoles__Team_TeamRole",
                table: "TeamsRoles",
                columns: new[] { "TeamRoleName", "TeamId" },
                unique: true);
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
