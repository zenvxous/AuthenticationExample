using Microsoft.EntityFrameworkCore;
using UserPlatform.Core.Interfaces.Repositories;
using UserPlatform.Core.Models;
using UserPlatform.Persistence.Entities;

namespace UserPlatform.Persistence.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UsersRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var userEntity = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
        
        return new User(userEntity.Id, userEntity.Name, userEntity.Email, userEntity.HashedPassword);
    }
    
    public async Task CreateAsync(User user)
    {
        var userEntity = new UserEntity
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            HashedPassword = user.HashedPassword
        };
        
       await _dbContext.Users.AddAsync(userEntity);
       await _dbContext.SaveChangesAsync();
    }


}