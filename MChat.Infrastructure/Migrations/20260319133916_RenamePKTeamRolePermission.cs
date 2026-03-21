using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MChat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamePKTeamRolePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams_Roles_Permissions",
                table: "TeamsRolesPermissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamsRolesPermissions",
                table: "TeamsRolesPermissions",
                column: "PermissionName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamsRolesPermissions",
                table: "TeamsRolesPermissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams_Roles_Permissions",
                table: "TeamsRolesPermissions",
                column: "PermissionName");
        }
    }
}
