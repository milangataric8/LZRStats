using Microsoft.EntityFrameworkCore.Migrations;

namespace LZRStatsApi.Migrations
{
    public partial class AddedSeasonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameType",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Game",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartYear = table.Column<int>(nullable: false),
                    EndYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_SeasonId",
                table: "Game",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Season_SeasonId",
                table: "Game",
                column: "SeasonId",
                principalTable: "Season",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Season_SeasonId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropIndex(
                name: "IX_Game_SeasonId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GameType",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Game");
        }
    }
}
