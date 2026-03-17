namespace MChat.Domain.Entities
{
    public class TeamChat
    {
        public Guid Id { get; private set; }

        public string TeamName { get; private set; } = string.Empty;

        public string? CoverImageUrl { get; private set; } = string.Empty;

        public User Creator { get; private set; }

        private TeamChat(Guid id, string teamName, string? coverImageUrl)
        {
            this.Id = id;
            this.TeamName = teamName;
            this.CoverImageUrl = coverImageUrl;
        }

        public TeamChat(Guid id, string teamName, string? coverImageUrl, User creator) : this(id, teamName, coverImageUrl)
        {
            this.Creator = creator;
        }
    }
}
