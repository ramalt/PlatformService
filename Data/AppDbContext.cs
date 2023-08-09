using Microsoft.EntityFrameworkCore;
using PlatformSerivce.Models;

namespace PlatformSerivce.Data;

public class AppDbContext : DbContext
{
     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
     {
        
     }

     public DbSet<Platform> Platforms { get; set; }
}
