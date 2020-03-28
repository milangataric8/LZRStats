﻿// <auto-generated />
using System;
using LZRStatsApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LZRStatsApi.Migrations
{
    [DbContext(typeof(LzrStatsContext))]
    partial class LzrStatsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LZRStatsApi.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MatchNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("PlayedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Round")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("LZRStatsApi.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GamesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("JerseyNumber")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("LZRStatsApi.Models.PlayerStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int>("Blocks")
                        .HasColumnType("int");

                    b.Property<int>("DefensiveRebounds")
                        .HasColumnType("int");

                    b.Property<int>("Efficiency")
                        .HasColumnType("int");

                    b.Property<int>("FG2Attempted")
                        .HasColumnType("int");

                    b.Property<int>("FG2Made")
                        .HasColumnType("int");

                    b.Property<int>("FG3Attempted")
                        .HasColumnType("int");

                    b.Property<int>("FG3Made")
                        .HasColumnType("int");

                    b.Property<int>("FTAttempted")
                        .HasColumnType("int");

                    b.Property<int>("FTMade")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("MinutesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("OffensiveRebounds")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Steals")
                        .HasColumnType("int");

                    b.Property<int>("TotalRebounds")
                        .HasColumnType("int");

                    b.Property<int>("Turnovers")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerStats");
                });

            modelBuilder.Entity("LZRStatsApi.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("LZRStatsApi.Models.TeamGame", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int>("Blocks")
                        .HasColumnType("int");

                    b.Property<int>("DefensiveRebounds")
                        .HasColumnType("int");

                    b.Property<int>("OffensiveRebounds")
                        .HasColumnType("int");

                    b.Property<int>("PointsScored")
                        .HasColumnType("int");

                    b.Property<int>("Steals")
                        .HasColumnType("int");

                    b.Property<int>("TotalRebounds")
                        .HasColumnType("int");

                    b.Property<int>("Turnovers")
                        .HasColumnType("int");

                    b.HasKey("TeamId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("TeamGame");
                });

            modelBuilder.Entity("LZRStatsApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Super",
                            LastName = "Admin",
                            Password = "admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("LZRStatsApi.Models.Player", b =>
                {
                    b.HasOne("LZRStatsApi.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LZRStatsApi.Models.PlayerStats", b =>
                {
                    b.HasOne("LZRStatsApi.Models.Game", "Game")
                        .WithMany("PlayerStats")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LZRStatsApi.Models.Player", "Player")
                        .WithMany("PlayerStats")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LZRStatsApi.Models.TeamGame", b =>
                {
                    b.HasOne("LZRStatsApi.Models.Game", "Game")
                        .WithMany("TeamGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LZRStatsApi.Models.Team", "Team")
                        .WithMany("TeamGames")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
