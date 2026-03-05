using System.ComponentModel.DataAnnotations;

namespace MChat.WebAPI.DTOs.Requests.Authentication
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email field is required.")]
        [EmailAddress]
        public required string Email { get; init; }

        [Required(ErrorMessage = "Password field is required.")]
        public required string Password { get; init; }
    }
}
