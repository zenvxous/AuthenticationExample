using Microsoft.AspNetCore.Http;

namespace UserPlatform.Core.Interfaces.Services;

public interface IUsersService
{
    Task RegisterUser(string name, string email, string password);
    Task<string> LoginUser(string email, string password, HttpContext context);
}