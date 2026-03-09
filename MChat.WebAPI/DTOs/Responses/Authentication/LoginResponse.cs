using MChat.Domain.Entities;

namespace MChat.WebAPI.DTOs.Responses.Authentication
{
    public class LoginResponse
    {
        public string AccessToken { get; init; }

        public string RefreshToken { get; init; }

        public LoginResponse(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
