using System.ComponentModel.DataAnnotations;

namespace UserPlatform.API.Contracts.Users;

public record class RegisterUserRequest(
    [Required] string Name,
    [Required] string Email,
    [Required] string Password);
