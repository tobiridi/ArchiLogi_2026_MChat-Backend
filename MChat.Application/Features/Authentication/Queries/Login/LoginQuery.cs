using Tools.CQS.Queries;

namespace MChat.Application.Features.Authentication.Queries.Login
{
    public class LoginQuery : IQueryDefinition
    {
        public string Email { get; }
        public string Password { get; }

        public LoginQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
