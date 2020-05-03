using Microsoft.EntityFrameworkCore.Migrations;

namespace LZRStatsApi.Migrations
{
    public partial class AddedSeasonIdToGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Season_SeasonId",
                table: "Game");

            migrationBuilder.AlterColumn<int>(
                name: "SeasonId",
                table: "Game",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Season",
                columns: new[] { "Id", "EndYear", "StartYear" },
                values: new object[,]
                {
                    { 1, 2014, 2013 },
                    { 2, 2015, 2014 },
                    { 3, 2017, 2016 },
                    { 4, 2019, 2018 },
                    { 5, 2020, 2019 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Season_SeasonId",
                table: "Game",
                column: "SeasonId",
                principalTable: "Season",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Season_SeasonId",
                table: "Game");

            migrationBuilder.DeleteData(
                table: "Season",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Season",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Season",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Season",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Season",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "SeasonId",
                table: "Game",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Season_SeasonId",
                table: "Game",
                column: "SeasonId",
                principalTable: "Season",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
