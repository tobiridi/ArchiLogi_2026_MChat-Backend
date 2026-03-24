namespace MChat.Domain.Entities.TeamChatting
{
    public class TeamChat
    {
        public Guid Id { get; set; }

        public string TeamName { get; set; }

        public string? CoverImageUrl { get; set; } = null;

        public User Creator { get; set; }

        public List<TeamRole> TeamRoles { get; set; }

        public List<TeamMember> TeamMembers { get; set; }

        public TeamChat() { }

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
