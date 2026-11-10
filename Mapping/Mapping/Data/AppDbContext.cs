using Microsoft.EntityFrameworkCore;
using Mapping.Model;

namespace Mapping.Data;

public class AppDbContext : DbContext
{
    public DbSet<UserDto> Users => Set<UserDto>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDto>();
    }
}