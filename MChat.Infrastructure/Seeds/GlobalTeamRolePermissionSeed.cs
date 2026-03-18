using MChat.Domain.Entities.TeamChatting;
using MChat.Domain.Enums;
using MChat.Infrastructure.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Seeds
{
    internal class GlobalTeamRolePermissionSeed : IEntityTypeConfiguration<GlobalTeamRolePermission>
    {
        public void Configure(EntityTypeBuilder<GlobalTeamRolePermission> builder)
        {
            GlobalTeamRolePermission[] data = [
                #region Owner
                
                new GlobalTeamRolePermission() {
                    PermissionName = TeamRolePermission.AllPermissions.PermissionName,
                    RoleName = GlobalTeamRoleName.Owner
                },
                #endregion

                #region Moderator

                new GlobalTeamRolePermission() {
                    PermissionName = TeamRolePermission.CreateChannel.PermissionName,
                    RoleName = GlobalTeamRoleName.Moderator
                },
                new GlobalTeamRolePermission() {
                    PermissionName = TeamRolePermission.UpdateChannel.PermissionName,
                    RoleName = GlobalTeamRoleName.Moderator
                },
                new GlobalTeamRolePermission() {
                    PermissionName = TeamRolePermission.DeleteChannel.PermissionName,
                    RoleName = GlobalTeamRoleName.Moderator
                },
                new GlobalTeamRolePermission() {
                    PermissionName = TeamRolePermission.ReadAllMessage.PermissionName,
                    RoleName = GlobalTeamRoleName.Moderator
                },
                new GlobalTeamRolePermission() {
                    PermissionName = TeamRolePermission.SendMessage.PermissionName,
                    RoleName = GlobalTeamRoleName.Moderator
                },
                new GlobalTeamRolePermission() {
                    PermissionName = TeamRolePermission.DeleteAnyMessage.PermissionName,
                    RoleName = GlobalTeamRoleName.Moderator
                },
                new GlobalTeamRolePermission() {
                    PermissionName = TeamRolePermission.DeleteOwnMessage.PermissionName,
                    RoleName = GlobalTeamRoleName.Moderator
                },
                new GlobalTeamRolePermission() {
                    PermissionName = TeamRolePermission.InviteUser.PermissionName,
                    RoleName = GlobalTeamRoleName.Moderator
                },
                new GlobalTeamRolePermission() {
                    PermissionName = TeamRolePermission.AssignRole.PermissionName,
                    RoleName = GlobalTeamRoleName.Moderator
                },
                #endregion

                #region Member

                new GlobalTeamRolePermission() {
                    PermissionName = TeamRolePermission.ReadAllMessage.PermissionName,
                    RoleName = GlobalTeamRoleName.Member
                },
                new GlobalTeamRolePermission() {
                    PermissionName = TeamRolePermission.SendMessage.PermissionName,
                    RoleName = GlobalTeamRoleName.Member
                },
                new GlobalTeamRolePermission() {
                    PermissionName = TeamRolePermission.DeleteOwnMessage.PermissionName,
                    RoleName = GlobalTeamRoleName.Member
                },
                #endregion
            ];

            builder.HasData(data);
        }
    }
}
