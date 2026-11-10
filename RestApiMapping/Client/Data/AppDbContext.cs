using Microsoft.EntityFrameworkCore;
using Client.Models;

namespace Client.Data;

    public class AppDbContext : DbContext
    {
        public DbSet<Models.Client> Clients => Set<Models.Client>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        //якщо є ще один класс
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Client>().OwnsOne(x => x.DateOfBirth);
        }
        
        // стандартно
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Client>();
        }
        */
    }
