using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MChat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameTableGlobalTeamRoleAndPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlobalTeamRolePermission_Global_Teams_Roles_RoleName",
                table: "GlobalTeamRolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_GlobalTeamRolePermission_Teams_Roles_Permissions_PermissionName",
                table: "GlobalTeamRolePermission");

            migrationBuilder.RenameTable(
                name: "Teams_Roles_Permissions",
                newName: "TeamsRolesPermissions");

            migrationBuilder.RenameTable(
                name: "Global_Teams_Roles",
                newName: "GlobalTeamsRoles");

            migrationBuilder.AddForeignKey(
                name: "FK_GlobalTeamRolePermission_GlobalTeamsRoles_RoleName",
                table: "GlobalTeamRolePermission",
                column: "RoleName",
                principalTable: "GlobalTeamsRoles",
                principalColumn: "global_role_name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GlobalTeamRolePermission_TeamsRolesPermissions_PermissionName",
                table: "GlobalTeamRolePermission",
                column: "PermissionName",
                principalTable: "TeamsRolesPermissions",
                principalColumn: "perm_name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlobalTeamRolePermission_GlobalTeamsRoles_RoleName",
                table: "GlobalTeamRolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_GlobalTeamRolePermission_TeamsRolesPermissions_PermissionName",
                table: "GlobalTeamRolePermission");

            migrationBuilder.RenameTable(
                name: "TeamsRolesPermissions",
                newName: "Teams_Roles_Permissions");

            migrationBuilder.RenameTable(
                name: "GlobalTeamsRoles",
                newName: "Global_Teams_Roles");

            migrationBuilder.AddForeignKey(
                name: "FK_GlobalTeamRolePermission_Global_Teams_Roles_RoleName",
                table: "GlobalTeamRolePermission",
                column: "RoleName",
                principalTable: "Global_Teams_Roles",
                principalColumn: "global_role_name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GlobalTeamRolePermission_Teams_Roles_Permissions_PermissionName",
                table: "GlobalTeamRolePermission",
                column: "PermissionName",
                principalTable: "Teams_Roles_Permissions",
                principalColumn: "perm_name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
