using Microsoft.EntityFrameworkCore.Migrations;

namespace LZRStatsApi.Migrations
{
    public partial class SeedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "GamesPlayed", "JerseyNumber", "LastName" },
                values: new object[] { "Player637175732079872749", 2, 1, "Lastname637175732079873310" });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "FirstName", "GamesPlayed", "JerseyNumber", "LastName", "TeamId" },
                values: new object[,]
                {
                    { 29, "Player31352156606849716", 58, 29, "Lastname31352156606849919", 1 },
                    { 30, "Player668527888686726044", 60, 30, "Lastname668527888686726254", 1 },
                    { 31, "Player1305703620766602400", 62, 31, "Lastname1305703620766602617", 1 },
                    { 32, "Player1942879352846478784", 64, 32, "Lastname1942879352846479008", 1 },
                    { 33, "Player2580055084926355196", 66, 33, "Lastname2580055084926355394", 1 },
                    { 34, "Player3217230817006231738", 68, 34, "Lastname3217230817006231976", 1 },
                    { 35, "Player3854406549086108209", 70, 35, "Lastname3854406549086108454", 1 },
                    { 36, "Player4491582281165984708", 72, 36, "Lastname4491582281165984960", 1 },
                    { 37, "Player5128758013245861235", 74, 37, "Lastname5128758013245861457", 1 },
                    { 38, "Player5765933745325737752", 76, 38, "Lastname5765933745325738018", 1 },
                    { 39, "Player6403109477405614295", 78, 39, "Lastname6403109477405614568", 1 },
                    { 40, "Player7040285209485490904", 80, 40, "Lastname7040285209485491184", 1 },
                    { 41, "Player7677460941565367541", 82, 41, "Lastname7677460941565367787", 1 },
                    { 42, "Player8314636673645244164", 84, 42, "Lastname8314636673645244458", 1 },
                    { 43, "Player8951812405725120856", 86, 43, "Lastname8951812405725121114", 1 },
                    { 44, "Player-8857755935904554084", 88, 44, "Lastname-8857755935904550124", 1 },
                    { 45, "Player-8220580203824673332", 90, 45, "Lastname-8220580203824672972", 1 },
                    { 46, "Player-7583404471744796376", 92, 46, "Lastname-7583404471744796054", 1 },
                    { 47, "Player-6946228739664919435", 94, 47, "Lastname-6946228739664919106", 1 },
                    { 48, "Player-6309053007585042464", 96, 48, "Lastname-6309053007585042128", 1 },
                    { 49, "Player-5671877275505165463", 98, 49, "Lastname-5671877275505165120", 1 },
                    { 28, "Player-605823575473026612", 56, 28, "Lastname-605823575473026416", 1 },
                    { 27, "Player-1242999307552902883", 54, 27, "Lastname-1242999307552902694", 1 },
                    { 2, "Player1274351464159750740", 4, 2, "Lastname1274351464159750802", 1 },
                    { 25, "Player-2517350771712655366", 50, 25, "Lastname-2517350771712655191", 1 },
                    { 4, "Player2548702928319501912", 8, 4, "Lastname2548702928319501940", 1 },
                    { 5, "Player3185878660399377460", 10, 5, "Lastname3185878660399377495", 1 },
                    { 6, "Player3823054392479253060", 12, 6, "Lastname3823054392479253102", 1 },
                    { 7, "Player4460230124559128668", 14, 7, "Lastname4460230124559128717", 1 },
                    { 8, "Player5097405856639004304", 16, 8, "Lastname5097405856639004360", 1 },
                    { 9, "Player5734581588718879968", 18, 9, "Lastname5734581588718880022", 1 },
                    { 10, "Player6371757320798755670", 20, 10, "Lastname6371757320798755740", 1 },
                    { 11, "Player7008933052878631391", 22, 11, "Lastname7008933052878631457", 1 },
                    { 12, "Player7646108784958507128", 24, 12, "Lastname7646108784958507212", 1 },
                    { 13, "Player8283284517038382904", 26, 13, "Lastname8283284517038382982", 1 },
                    { 14, "Player8920460249118258694", 28, 14, "Lastname8920460249118258792", 1 },
                    { 15, "Player-8889108092511417091", 30, 15, "Lastname-8889108092511416941", 1 },
                    { 16, "Player-8251932360431541152", 32, 16, "Lastname-8251932360431541024", 1 },
                    { 17, "Player-7614756628351665243", 34, 17, "Lastname-7614756628351665124", 1 },
                    { 18, "Player-6977580896271789250", 36, 18, "Lastname-6977580896271789106", 1 },
                    { 19, "Player-6340405164191913278", 38, 19, "Lastname-6340405164191913145", 1 },
                    { 20, "Player-5703229432112037276", 40, 20, "Lastname-5703229432112037136", 1 },
                    { 21, "Player-5066053700032161244", 42, 21, "Lastname-5066053700032161097", 1 },
                    { 22, "Player-4428877967952284038", 44, 22, "Lastname-4428877967952283774", 1 },
                    { 23, "Player-3791702235872407779", 46, 23, "Lastname-3791702235872407595", 1 },
                    { 24, "Player-3154526503792531552", 48, 24, "Lastname-3154526503792531384", 1 },
                    { 3, "Player1911527196239626374", 6, 3, "Lastname1911527196239626407", 1 },
                    { 26, "Player-1880175039632779152", 52, 26, "Lastname-1880175039632778970", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Losses", "Name", "Wins" },
                values: new object[] { 0, "Team637175732079836597", 1 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Losses", "Name", "Wins" },
                values: new object[,]
                {
                    { 48, 47, "Team-6309053007585334832", 48 },
                    { 29, 28, "Team31352156606679341", 29 },
                    { 30, 29, "Team668527888686549614", 30 },
                    { 31, 30, "Team1305703620766419872", 31 },
                    { 32, 31, "Team1942879352846290176", 32 },
                    { 33, 32, "Team2580055084926160463", 33 },
                    { 34, 33, "Team3217230817006030866", 34 },
                    { 35, 34, "Team3854406549085901254", 35 },
                    { 36, 35, "Team4491582281165771588", 36 },
                    { 37, 36, "Team5128758013245641973", 37 },
                    { 49, 48, "Team-5671877275505464265", 49 },
                    { 28, 27, "Team-605823575473190944", 28 },
                    { 39, 38, "Team6403109477405382674", 39 },
                    { 40, 39, "Team7040285209485253064", 40 },
                    { 41, 40, "Team7677460941565123468", 41 },
                    { 42, 41, "Team8314636673644993886", 42 },
                    { 43, 42, "Team8951812405724864275", 43 },
                    { 44, 43, "Team-8857755935904816896", 44 },
                    { 45, 44, "Team-8220580203824946347", 45 },
                    { 46, 45, "Team-7583404471745075872", 46 },
                    { 47, 46, "Team-6946228739665205336", 47 },
                    { 38, 37, "Team5765933745325512298", 38 },
                    { 27, 26, "Team-1242999307553061157", 27 },
                    { 15, 14, "Team-8889108092511505636", 15 },
                    { 25, 24, "Team-2517350771712801566", 25 },
                    { 3, 2, "Team1911527196239608887", 3 },
                    { 4, 3, "Team2548702928319478568", 4 },
                    { 5, 4, "Team3185878660399348250", 5 },
                    { 6, 5, "Team3823054392479217972", 6 },
                    { 7, 6, "Team4460230124559087690", 7 },
                    { 8, 7, "Team5097405856638957424", 8 },
                    { 9, 8, "Team5734581588718827165", 9 },
                    { 10, 9, "Team6371757320798696950", 10 },
                    { 11, 10, "Team7008933052878566744", 11 },
                    { 12, 11, "Team7646108784958436532", 12 },
                    { 13, 12, "Team8283284517038306334", 13 },
                    { 14, 13, "Team8920460249118176150", 14 },
                    { 16, 15, "Team-8251932360431634000", 16 },
                    { 17, 16, "Team-7614756628351763826", 17 },
                    { 18, 17, "Team-6977580896271892660", 18 },
                    { 19, 18, "Team-6340405164192022471", 19 },
                    { 20, 19, "Team-5703229432112152356", 20 },
                    { 21, 20, "Team-5066053700032282225", 21 },
                    { 22, 21, "Team-4428877967952412078", 22 },
                    { 23, 22, "Team-3791702235872541915", 23 },
                    { 24, 23, "Team-3154526503792671760", 24 },
                    { 26, 25, "Team-1880175039632931356", 26 },
                    { 2, 1, "Team1274351464159739116", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.UpdateData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "GamesPlayed", "JerseyNumber", "LastName" },
                values: new object[] { "Player 1", 0, 8, "Lastname" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Losses", "Name", "Wins" },
                values: new object[] { 1, "SkyWalkers", 8 });
        }
    }
}
