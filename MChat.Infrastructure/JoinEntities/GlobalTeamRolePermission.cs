using MChat.Domain.Entities.TeamChatting;
using MChat.Domain.Enums;

namespace MChat.Infrastructure.JoinEntities
{
    /// <summary>
    /// Join entity to link <c>GlobalTeamRole</c> with <c>TeamRolePermission</c>.
    /// </summary>
    internal class GlobalTeamRolePermission
    {
        public string PermissionName { get; set; }

        public GlobalTeamRoleName RoleName { get; set; }
    }
}
