using MChat.Domain.Enums;

namespace MChat.Domain.Entities.TeamChatting
{
    /// <summary>
    /// A user role for a team chat.
    /// </summary>
    /// <remarks>
    /// Restrict the user action in a team chat.
    /// </remarks>
    public class TeamRole
    {
        public Guid Id { get; private set; }

        /// <summary>
        /// The name of the team role.
        /// </summary>
        /// <remarks>
        /// The role name is always in lowercase.
        /// </remarks>
        public string TeamRoleName { get; private set; }

        public List<TeamRolePermission> Permissions { get; private set; }

        public Guid? TeamId { get; private set; }

        public TeamChat? Team { get; private set; }

        /// <summary>
        /// Determine if the <see cref="TeamRole"/> is a global role defined by the app or not.
        /// <seealso cref="GlobalTeamRoleName"/>
        /// </summary>
        public bool IsGlobalRole { 
            get { return this.Team is null || this.TeamId is null; } 
        }

        public IEnumerable<TeamMember> TeamMembers { get; private set; }

        private TeamRole(Guid id, string teamRoleName)
        {
            Id = id;
            TeamRoleName = teamRoleName.Trim().ToLowerInvariant();
        }

        public TeamRole(Guid id, string teamRoleName, List<TeamRolePermission> permissions, TeamChat? teamChat, IEnumerable<TeamMember> teamMembers) : this(id, teamRoleName)
        {
            Permissions = permissions;
            Team = teamChat;
            TeamId = teamChat?.Id;
            TeamMembers = teamMembers;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj.GetType() != typeof(User)) return false;
            if (obj == this) return true;
            TeamRole tr = obj as TeamRole;
            return tr.TeamRoleName == TeamRoleName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TeamRoleName, Permissions);
        }
    }
}
