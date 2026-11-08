using Microsoft.EntityFrameworkCore;
using TRY.Models;

namespace TRY.Data;

public class PhoneDb : DbContext
{
    public PhoneDb(DbContextOptions<PhoneDb> options)
        : base(options)
    {
    }

    public DbSet<Phone> Phones => Set<Phone>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Phone>()
            .HasIndex(p => p.AppleID)
            .IsUnique();
    }
}