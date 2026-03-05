using System.ComponentModel.DataAnnotations;

namespace MChat.WebAPI.DTOs.Requests.Authentication
{
    public record AuthenticateRequest
    {
        [Required(ErrorMessage = "Email field is required.")]
        [EmailAddress]
        public required string Email { get; init; }

        [Required(ErrorMessage = "Password field is required.")]
        public required string Password { get; init; }

        [Required(ErrorMessage = "Username field is required.")]
        [MinLength(3, ErrorMessage = "The username must have at least 3 characters.")]
        public required string Username { get; init; }
    }
}
