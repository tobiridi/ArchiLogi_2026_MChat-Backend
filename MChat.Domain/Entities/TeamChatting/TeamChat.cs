namespace MChat.Domain.Entities.TeamChatting
{
    public class TeamChat
    {
        public Guid Id { get; private set; }

        public string TeamName { get; private set; }

        public string? CoverImageUrl { get; private set; } = null;

        public User Creator { get; private set; }

        public List<TeamRole> TeamRoles { get; private set; }

        public List<TeamMember> TeamMembers { get; private set; }

        private TeamChat(Guid id, string teamName, string? coverImageUrl)
        {
            Id = id;
            TeamName = teamName;
            CoverImageUrl = coverImageUrl;
        }

        public TeamChat(Guid id, string teamName, string? coverImageUrl, User creator, List<TeamRole> teamRoles, List<TeamMember> teamMembers) : this(id, teamName, coverImageUrl)
        {
            Creator = creator;
            TeamRoles = teamRoles;
            TeamMembers = teamMembers;
        }
    }
}
