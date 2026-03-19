namespace MChat.Domain.Entities.TeamChatting
{
    public class TeamChat
    {
        public Guid Id { get; private set; }

        public string TeamName { get; private set; } = string.Empty;

        public string? CoverImageUrl { get; private set; } = string.Empty;

        public User Creator { get; private set; }

        //public List<TeamRole> TeamRoles { get; private set; }

        private TeamChat(Guid id, string teamName, string? coverImageUrl)
        {
            Id = id;
            TeamName = teamName;
            CoverImageUrl = coverImageUrl;
        }

        public TeamChat(Guid id, string teamName, string? coverImageUrl, User creator, List<TeamRole> teamRoles) : this(id, teamName, coverImageUrl)
        {
            Creator = creator;
            //TeamRoles = teamRoles;
        }
    }
}
