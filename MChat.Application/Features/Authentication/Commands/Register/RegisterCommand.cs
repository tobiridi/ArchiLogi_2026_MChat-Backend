using Tools.CQS.Commands;

namespace MChat.Application.Features.Authentication.Commands.Register
{
    public class RegisterCommand : ICommandDefinition
    {
        public string Email { get; }
        public string Password { get; }
        public string Username { get; }

        public RegisterCommand(string email, string password, string username)
        {
            this.Email = email;
            this.Password = password;
            this.Username = username;
        }
    }
}
