using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LZRStatsApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayedOn = table.Column<DateTime>(nullable: false),
                    Round = table.Column<int>(nullable: false),
                    MatchNumber = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Wins = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    JerseyNumber = table.Column<int>(nullable: false),
                    GamesPlayed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamGame",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    PointsScored = table.Column<int>(nullable: false),
                    TotalRebounds = table.Column<int>(nullable: false),
                    OffensiveRebounds = table.Column<int>(nullable: false),
                    DefensiveRebounds = table.Column<int>(nullable: false),
                    Assists = table.Column<int>(nullable: false),
                    Turnovers = table.Column<int>(nullable: false),
                    Steals = table.Column<int>(nullable: false),
                    Blocks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamGame", x => new { x.TeamId, x.GameId });
                    table.ForeignKey(
                        name: "FK_TeamGame_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamGame_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    OffensiveRebounds = table.Column<int>(nullable: false),
                    DefensiveRebounds = table.Column<int>(nullable: false),
                    TotalRebounds = table.Column<int>(nullable: false),
                    Assists = table.Column<int>(nullable: false),
                    Steals = table.Column<int>(nullable: false),
                    Blocks = table.Column<int>(nullable: false),
                    Turnovers = table.Column<int>(nullable: false),
                    Efficiency = table.Column<int>(nullable: false),
                    FG2Attempted = table.Column<int>(nullable: false),
                    FG2Made = table.Column<int>(nullable: false),
                    FG3Attempted = table.Column<int>(nullable: false),
                    FG3Made = table.Column<int>(nullable: false),
                    FTAttempted = table.Column<int>(nullable: false),
                    FTMade = table.Column<int>(nullable: false),
                    MinutesPlayed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStats_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStats_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { 1, "Super", "Admin", "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_GameId",
                table: "PlayerStats",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_PlayerId",
                table: "PlayerStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGame_GameId",
                table: "TeamGame",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerStats");

            migrationBuilder.DropTable(
                name: "TeamGame");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
