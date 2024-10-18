using Microsoft.AspNetCore.Http;
using UserPlatform.Core.Interfaces.Auth;
using UserPlatform.Core.Interfaces.Repositories;
using UserPlatform.Core.Interfaces.Services;
using UserPlatform.Core.Models;

namespace UserPlatform.BL.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public UsersService(IUsersRepository usersRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task RegisterUser(string name, string email, string password)
    {
        var hashedPassword = _passwordHasher.HashPassword(password);
        
        var user = new User(Guid.NewGuid(), name, email, hashedPassword);
        
        await _usersRepository.CreateAsync(user);
    }

    public async Task<string> LoginUser(string email, string password, HttpContext context)
    {
        var user = await _usersRepository.GetByEmailAsync(email);
        
        if(!_passwordHasher.VerifyHashedPassword(user.HashedPassword, password))
            throw new Exception("Invalid password");
        
        var token = _jwtProvider.GenerateToken(user);
        
        context.Response.Cookies.Append("token", token);
        
        return token;
    }
}