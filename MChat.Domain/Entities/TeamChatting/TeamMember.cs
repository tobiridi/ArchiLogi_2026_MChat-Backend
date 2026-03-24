namespace MChat.Domain.Entities.TeamChatting
{
    public class TeamMember
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid TeamId { get; set; }
        public TeamChat Team { get; set; }

        public Guid TeamRoleId { get; set; }
        public TeamRole TeamRole { get; set; }

        public TeamMember() { }

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
