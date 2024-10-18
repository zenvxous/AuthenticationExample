using Microsoft.Extensions.Options;

namespace UserPlatform.BL;

public class JwtOptions
{
    public string SecretKey { get; set; } = string.Empty;

    public int ExpiresHours { get; set; }
}