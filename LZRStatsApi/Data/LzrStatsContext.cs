using LZRStatsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LZRStatsApi.Data
{
    public class LzrStatsContext : DbContext
    {
        public LzrStatsContext(DbContextOptions<LzrStatsContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Super", LastName = "Admin", Username = "admin", Password = "admin" });
        }
    }
}
