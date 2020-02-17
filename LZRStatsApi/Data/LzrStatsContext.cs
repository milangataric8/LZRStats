using LZRStatsApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

            //modelBuilder.Entity<Team>()
            //    .Property(t => t.Id)
            //    .ValueGeneratedOnAdd();
            var teams = new List<Team>();
            for (int i = 1; i < 50; i++)
            {
                teams.Add(new Team { Id = i, Name = "Team" + DateTime.Now.Ticks * i, Wins = i, Losses = i - 1 });
            }

            modelBuilder.Entity<Team>().HasData(teams);

            //modelBuilder.Entity<Player>()
            //    .Property(t => t.Id)
            //    .ValueGeneratedOnAdd();
            var players = new List<Player>();
            for (int i = 1; i < 50; i++)
            {
                players.Add(new Player { Id = i, FirstName = "Player" + DateTime.Now.Ticks * i, LastName = "Lastname" + DateTime.Now.Ticks * i, GamesPlayed = 2 * i, TeamId = 1, JerseyNumber = i });
            }

            modelBuilder.Entity<Player>().HasData(players);
        }

    }
}
