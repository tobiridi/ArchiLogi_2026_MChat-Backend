namespace MChat.Domain.Entities
{
    public class JwtRefreshTokenUser
    {
        public string RefreshToken { get; private set; }

        public User User { get; private set; }

        public DateTime ExpiresAt { get; private set; }

        public bool IsRevoked {
            get { return this.ExpiresAt < DateTime.UtcNow; }
            private set { }
        }

        private JwtRefreshTokenUser() { }

        public JwtRefreshTokenUser(string refreshToken, User user, DateTime expiresAt, bool isRevoked)
        {
            RefreshToken = refreshToken;
            User = user;
            ExpiresAt = expiresAt;
            IsRevoked = isRevoked;
        }
    }
}
