using MChat.Domain.Entities;

namespace MChat.WebAPI.DTOs.Responses.Authentication
{
    public class LoginResponse
    {
        //public Guid Id { get; init; }

        //public string Email { get; init; }

        //public string Username { get; init; }

        //public DateOnly CreateAt { get; init; }

        //public DateTime LastUpdate { get; init; }

        public string AccessToken { get; init; }

        public string RefreshToken { get; init; }

        public LoginResponse(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        //public LoginResponse(User user)
        //{
        //    Id = user.Id;
        //    Email = user.Email!;
        //    Username = user.Username;
        //    CreateAt = user.CreateAt;
        //    LastUpdate = user.LastUpdate;
        //}


    }
}
