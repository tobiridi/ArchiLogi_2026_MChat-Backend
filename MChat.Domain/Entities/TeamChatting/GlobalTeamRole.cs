using MChat.Domain.Enums;

namespace MChat.Domain.Entities.TeamChatting
{
    public class GlobalTeamRole
    {
        public GlobalTeamRoleName GlobalRoleName { get; private set; }

        public IEnumerable<TeamRolePermission> Permissions { get; private set; }

        private GlobalTeamRole(GlobalTeamRoleName globalRoleName)
        {
            GlobalRoleName = globalRoleName;
        }

        public GlobalTeamRole(GlobalTeamRoleName globalRoleName, IEnumerable<TeamRolePermission> permissions) : this(globalRoleName)
        {
            Permissions = permissions;
        }
    }
}
