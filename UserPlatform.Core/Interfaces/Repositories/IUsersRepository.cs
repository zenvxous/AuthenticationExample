using UserPlatform.Core.Models;

namespace UserPlatform.Core.Interfaces.Repositories;

public interface IUsersRepository
{
    Task<User> GetByEmailAsync(string email);
    Task CreateAsync(User user);
}