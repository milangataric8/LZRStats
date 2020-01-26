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
        public DbSet<Player> Player { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Super", LastName = "Admin", Username = "admin", Password = "admin" });

            modelBuilder.Entity<Team>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "SkyWalkers", Wins = 8, Loses = 1});

            modelBuilder.Entity<Player>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Player>().HasData(
                new Player { Id = 1, Name = "Player 1",JerseyNumber = 8, Team = "test team" });
        }

    }
}
