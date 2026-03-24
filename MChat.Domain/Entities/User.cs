using MChat.Domain.Entities.TeamChatting;

namespace MChat.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string? Email { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public DateOnly CreateAt { get; set; }

        public DateTime LastUpdate { get; set; }

        public List<TeamChat> MyTeamChats { get; set; }

        public IEnumerable<TeamMember> TeamMembers { get; set; }

        public User() {}

        public User(string? email, string password, string username) {
            this.Email = email;
            this.Password = password;
            this.Username = username;
            this.MyTeamChats = [];
            this.TeamMembers = [];
        }

        public User(Guid id, string? email, string password, string username, DateOnly createAt, DateTime lastUpdate) : this(email, password, username)
        {
            this.Id = id;
            this.CreateAt = createAt;
            this.LastUpdate = lastUpdate;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj.GetType() != typeof(User)) return false;
            if (obj == this) return true;
            User u = obj as User;
            return u.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Email, Password, Username, CreateAt, LastUpdate);
        }
    }
}
