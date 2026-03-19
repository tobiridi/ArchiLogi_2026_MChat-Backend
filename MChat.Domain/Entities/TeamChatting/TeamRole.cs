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

        //public List<User> Users { get; private set; }

        private TeamRole(Guid id, string teamRoleName)
        {
            Id = id;
            TeamRoleName = teamRoleName.Trim().ToLowerInvariant();
        }

        public TeamRole(Guid id, string teamRoleName, List<TeamRolePermission> permissions, TeamChat teamChat /*, List<User>? usersInRole*/) : this(id, teamRoleName)
        {
            Permissions = permissions;
            Team = teamChat;
            //Users = usersInRole ?? new List<User>();
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
