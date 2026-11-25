using Microsoft.EntityFrameworkCore;
using ServerB.Result;
namespace ServerB;

public class ClinicDbContext(DbContextOptions<ClinicDbContext> options) : DbContext(options)
{
    public DbSet<PatientRecordEntity> Patients => Set<PatientRecordEntity>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<PatientRecordEntity>()
            .HasMany(p => p.Alerts)
            .WithOne()
            .HasForeignKey(a => a.PatientRecordId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Entity<PatientRecordEntity>()
            .HasMany(p => p.Consultations)
            .WithOne()
            .HasForeignKey(c => c.PatientRecordId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}