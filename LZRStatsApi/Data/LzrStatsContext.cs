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

            modelBuilder.Entity<Team>()
               .HasMany(x => x.Players)
               .WithOne(x => x.Team)
               .HasForeignKey(x => x.TeamId);

            modelBuilder.Entity<TeamGame>().HasKey(q =>
                new {
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

            //modelBuilder.Entity<Team>()
            //    .Property(t => t.Id)
            //    .ValueGeneratedOnAdd();
            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "SkyWalkers", Wins = 8, Losses = 1 });

            //modelBuilder.Entity<Player>()
            //    .Property(t => t.Id)
            //    .ValueGeneratedOnAdd();
            modelBuilder.Entity<Player>().HasData(
                new Player { Id = 1, FirstName = "Player 1", LastName = "Lastname", GamesPlayed = 0, TeamId = 1, JerseyNumber = 8 });
        }

    }
}
