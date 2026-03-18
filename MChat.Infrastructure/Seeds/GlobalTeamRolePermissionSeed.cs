using MChat.Domain.Entities.TeamChatting;
using MChat.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Seeds
{
    internal class GlobalTeamRolePermissionSeed : IEntityTypeConfiguration<GlobalTeamRole>
    {
        public void Configure(EntityTypeBuilder<GlobalTeamRole> builder)
        {
            GlobalTeamRole[] data = [
                new GlobalTeamRole(GlobalTeamRoleName.Owner,
                permissions: [
                    //TeamRolePermission.AllPermissions
                ]),

                new GlobalTeamRole(GlobalTeamRoleName.Moderator,
                permissions: [
                    //TeamRolePermission.CreateChannel,
                    //TeamRolePermission.UpdateChannel,
                    //TeamRolePermission.DeleteChannel,
                    //TeamRolePermission.ReadAllMessage,
                    //TeamRolePermission.SendMessage,
                    //TeamRolePermission.DeleteAnyMessage,
                    //TeamRolePermission.DeleteOwnMessage,
                    //TeamRolePermission.InviteUser,
                    //TeamRolePermission.AssignRole,
                ]),

                new GlobalTeamRole(GlobalTeamRoleName.Member,
                permissions: [
                    //TeamRolePermission.ReadAllMessage,
                    //TeamRolePermission.SendMessage,
                    //TeamRolePermission.DeleteOwnMessage
                ]),

            ];

            builder.HasData(data);
        }
    }
}
