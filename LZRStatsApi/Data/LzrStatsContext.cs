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
        public DbSet<Season> Season { get; set; }
        public DbSet<FileImportHistory> FileImportHistory { get; set; }

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

            modelBuilder.Entity<Season>()
                .HasMany(x => x.Games)
                .WithOne(x => x.Season)
                .HasForeignKey(x => x.SeasonId);

            modelBuilder.Entity<User>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Super", LastName = "Admin", Username = "admin", Password = "admin" });

            modelBuilder.Entity<Season>().HasData(
                    new Season { Id = 1, StartYear = 2014, EndYear = 2015 },
                    new Season { Id = 2, StartYear = 2016, EndYear = 2017 },
                    new Season { Id = 3, StartYear = 2018, EndYear = 2019 },
                    new Season { Id = 4, StartYear = 2019, EndYear = 2020 },
                    new Season { Id = 5, StartYear = 2020, EndYear = 2021 }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
