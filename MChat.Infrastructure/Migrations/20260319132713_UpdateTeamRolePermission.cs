using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MChat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeamRolePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Teams_Roles_Permissions",
                newName: "TeamsRolesPermissions");

            migrationBuilder.RenameColumn(
                name: "perm_name",
                table: "TeamsRolesPermissions",
                newName: "PermissionName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TeamsRolesPermissions",
                newName: "Teams_Roles_Permissions");

            migrationBuilder.RenameColumn(
                name: "PermissionName",
                table: "Teams_Roles_Permissions",
                newName: "perm_name");
        }
    }
}
