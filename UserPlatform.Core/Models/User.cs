namespace UserPlatform.Core.Models;

public class User
{
    public User(Guid id, string name, string email, string hashedPassword)
    {
        Id = id;
        Name = name;
        Email = email;
        HashedPassword = hashedPassword;
    }
    
    public Guid Id { get; private set; }
    
    public string Name { get; private set; }
    
    public string Email { get; private set; }
    
    public string HashedPassword { get; private set; }
}