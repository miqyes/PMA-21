using Microsoft.EntityFrameworkCore;
using MyRestAPI.Models;

namespace MyRestAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students => Set<Student>();
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().OwnsOne(s => s.BirthDate);
    }
}