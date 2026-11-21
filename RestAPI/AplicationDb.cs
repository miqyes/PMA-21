using Microsoft.EntityFrameworkCore;
public class AplicationDb : DbContext
{
    public AplicationDb(DbContextOptions<AplicationDb> options) : base(options)
    {
    }
    public DbSet<Order> Orders { get; set; }
}