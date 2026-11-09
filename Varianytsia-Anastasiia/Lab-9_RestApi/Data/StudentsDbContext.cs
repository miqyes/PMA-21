using Microsoft.EntityFrameworkCore;

namespace StudentRestApi.Data;

// Контекст EF Core: описує підключення до бази і таблицю студентів.
public class StudentsDbContext : DbContext
{
    public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(student =>
        {
            student.ToTable("Students");
            student.HasKey(s => s.Id);
            student.Property(s => s.FirstName).IsRequired();
            student.Property(s => s.LastName).IsRequired();
            student.Property(s => s.BirthDate).HasColumnType("date");
            student.Property(s => s.Grades).HasColumnType("integer[]").IsRequired();
        });
    }
}
