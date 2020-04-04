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
        public DbSet<Team> Team { get; set; }
        public DbSet<Player> Player { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Team>()
               .HasMany(x => x.Players)
               .WithOne(x => x.Team)
               .HasForeignKey(x => x.TeamId);

            modelBuilder.Entity<TeamGame>().HasKey(q =>
                new
                {
                    q.TeamId,
                    q.GameId
                });

            // Relationships
            modelBuilder.Entity<TeamGame>()
                .HasOne(t => t.Team)
                .WithMany(t => t.TeamGames)
                .HasForeignKey(t => t.TeamId);

            modelBuilder.Entity<TeamGame>()
                .HasOne(t => t.Game)
                .WithMany(t => t.TeamGames)
                .HasForeignKey(t => t.GameId);


            modelBuilder.Entity<Player>()
                    .HasMany(x => x.PlayerStats)
                    .WithOne(x => x.Player)
                    .HasForeignKey(x => x.PlayerId);

            modelBuilder.Entity<Game>()
                .HasMany(x => x.PlayerStats)
                .WithOne(x => x.Game)
                .HasForeignKey(x => x.GameId);

            modelBuilder.Entity<User>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Super", LastName = "Admin", Username = "admin", Password = "admin" });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
