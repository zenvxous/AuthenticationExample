using UserPlatform.Core.Models;

namespace UserPlatform.Core.Interfaces.Auth;

public interface IJwtProvider
{
    string GenerateToken(User user);
}