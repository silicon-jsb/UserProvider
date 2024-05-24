using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Data.Contexts;

public class DataContext : IdentityDbContext<ApplicationUser>
{
    private readonly IConfiguration _configuration;

    public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<UserAddress> Addresses { get; set; }
    public DbSet<UserBasicInfo> UserBasicInfo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = System.Environment.GetEnvironmentVariable("USERS_DATABASE");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }


}


