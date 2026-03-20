namespace MChat.Domain.Entities.TeamChatting
{
    public class TeamMember
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public Guid TeamId { get; private set; }
        public TeamChat Team { get; private set; }

        public Guid TeamRoleId { get; private set; }
        public TeamRole TeamRole { get; private set; }

        private TeamMember() { }

        public TeamMember(User user, TeamChat teamChat, TeamRole teamRole)
        {
            UserId = user.Id;
            User = user;
            TeamId = teamChat.Id;
            Team = teamChat;
            TeamRoleId = teamRole.Id;
            TeamRole = teamRole;
        }
    }
}
