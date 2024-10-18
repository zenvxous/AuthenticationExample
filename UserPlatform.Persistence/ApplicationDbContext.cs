using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserPlatform.Core.Models;
using UserPlatform.Persistence.Entities;

namespace UserPlatform.Persistence;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public DbSet<UserEntity> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("ApplicationDbContext"));
    }
}