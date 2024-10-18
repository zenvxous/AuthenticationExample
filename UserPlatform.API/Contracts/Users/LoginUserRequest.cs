using System.ComponentModel.DataAnnotations;

namespace UserPlatform.API.Contracts.Users;

public record class LoginUserRequest(
    [Required] string Email,
    [Required] string Password);
