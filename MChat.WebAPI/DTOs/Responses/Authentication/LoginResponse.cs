using MChat.Domain.Entities;

namespace MChat.WebAPI.DTOs.Responses.Authentication
{
    public class LoginResponse
    {
        public Guid Id { get; init; }

        public string Email { get; init; }

        public string Username { get; init; }

        public DateOnly CreateAt { get; init; }

        public DateTime LastUpdate { get; init; }

        public LoginResponse(User user)
        {
            Id = user.Id;
            Email = user.Email!;
            Username = user.Username;
            CreateAt = user.CreateAt;
            LastUpdate = user.LastUpdate;
        }
    }
}
