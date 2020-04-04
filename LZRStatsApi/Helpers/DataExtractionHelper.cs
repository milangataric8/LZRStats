using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using LZRStatsApi.Models;
using LZRStatsApi.Models.Dtos;
using LZRStatsApi.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Helpers
{
    public static class DataExtractionHelper
    {
        private const int GameRelatedDataCount = 21;
        private const int SinglePlayerRelatedDataCount = 20;
        private const string OppTeamNameAndDatePlayedSeparator = "[vs";
        private const char FgStatSeparator = '/';
        private const int DataToSkipFirstCount = 19;
        private const int DataToSkipLastCount = 18;


        public static List<string> GetFileData(this string filePath)
        {
            List<string> data = new List<string>();
            using var doc = WordprocessingDocument.Open(filePath, false);
            var paragraphs = doc.MainDocumentPart.Document.Body.Elements().OfType<Paragraph>().ToList().Skip(1);
            foreach (var el in paragraphs)
            {
                if (!string.IsNullOrEmpty(el.InnerText))
                    data.Add(el.InnerText);
            }

            return data;
        }

        public static int GetNumberValue(this List<string> data, int statIndex)
        {
            bool isParsed = int.TryParse(data[(int)statIndex], out int result);
            result = isParsed ? result : 0;

            return result;
        }

        public static FieldGoal GetFGStatValue(this List<string> data, int fGStatIndex)
        {
            var value = data[fGStatIndex]?.Split(FgStatSeparator);
            bool isMadeParsed = int.TryParse(value[0], out int made);

            if (!isMadeParsed)
                return new FieldGoal(0, 0);

            int.TryParse(value[1], out int attempted);

            return new FieldGoal(made, attempted);
        }

        public static string GetTextValue(this List<string> data, int statIndex)
        {
            return data[statIndex];
        }

        public static string GetTeamName(this List<string> data)
        {
            string name = data[data.Count - 1];
            return name.RemoveNonLetterCharactersAndEmptySpaces(); //TODO remove special chars and spaces
        }

        public static string GetOpposingTeamName(this List<string> data)
        {
            return data[data.Count - 2]?.Split(OppTeamNameAndDatePlayedSeparator)[1].RemoveNonLetterCharactersAndEmptySpaces();
        }

        public static DateTime GetDatePlayed(this List<string> data)
        {
            var val = data[data.Count - 2].Split(OppTeamNameAndDatePlayedSeparator)[0].Trim();

            var isParsed = DateTime.TryParseExact(val, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime myDate);

            return isParsed ? myDate : DateTime.Now;
        }

        public static int GetNumberOfPlayers(this List<string> data)
        {
            int count = (data.Count - GameRelatedDataCount) / SinglePlayerRelatedDataCount;

            return count;
        }

        private static string[] SplitFullName(string fullName)
        {
            return fullName.Split(null);
        }

        public static async Task<List<Player>> ExtractPlayers(this List<string> data, int teamId, Game game, IPlayerRepository repo)
        {
            var playersData = data.Skip(DataToSkipFirstCount).SkipLast(DataToSkipLastCount).ToList();
            var players = playersData.ChunkBy(SinglePlayerRelatedDataCount);
            var result = new List<Player>();
            foreach (var playerData in players)
            {
                Player player =  await playerData.ExtractPlayerInfo(teamId, repo);
                player.PlayerStats.Add(ExtractPlayerStats(playerData, game));
                result.Add(player);
            }

            return result;
        }

        private static async Task<Player> ExtractPlayerInfo(this List<string> playerData, int teamId, IPlayerRepository repo)
        {
            var name = playerData.GetTextValue((int)PlayerStatIndex.Name);
            var separatedName = SplitFullName(name);
            string firstName = separatedName[0];
            string lastName = separatedName[1];
            int jerseyNo = playerData.GetNumberValue((int)PlayerStatIndex.Number);
            var player = await repo.Find(teamId, lastName, firstName, jerseyNo) ?? new Player
            {
                FirstName = firstName,
                LastName = lastName,
                JerseyNumber = jerseyNo,
                GamesPlayed = 1,
                PlayerStats = new List<PlayerStats>()
            };

            return player;
        }

        private static PlayerStats ExtractPlayerStats(List<string> playerData, Game game)
        {
            var fg = playerData.GetFGStatValue((int)PlayerStatIndex.FG);
            var fg2 = playerData.GetFGStatValue((int)PlayerStatIndex.FG2);
            var fg3 = playerData.GetFGStatValue((int)PlayerStatIndex.FG3);
            var ft = playerData.GetFGStatValue((int)PlayerStatIndex.FT);
            PlayerStats stats = playerData.GetPlayerStats(fg2, fg3, ft, game);

            return stats;
        }

        private static PlayerStats GetPlayerStats(this List<string> playerData, FieldGoal fg2, FieldGoal fg3, FieldGoal ft, Game game)
        {
            return new PlayerStats
            {
                MinutesPlayed = playerData.GetNumberValue((int)PlayerStatIndex.MinutesPlayed),
                Efficiency = playerData.GetNumberValue((int)PlayerStatIndex.Efficiency),
                TotalRebounds = playerData.GetNumberValue((int)PlayerStatIndex.Rebounds),
                OffensiveRebounds = playerData.GetNumberValue((int)PlayerStatIndex.OffensiveRebounds),
                DefensiveRebounds = playerData.GetNumberValue((int)PlayerStatIndex.DefensiveRebounds),
                Assists = playerData.GetNumberValue((int)PlayerStatIndex.Assists),
                Turnovers = playerData.GetNumberValue((int)PlayerStatIndex.Turnovers),
                Steals = playerData.GetNumberValue((int)PlayerStatIndex.Steals),
                Blocks = playerData.GetNumberValue((int)PlayerStatIndex.Blocks),
                Points = playerData.GetNumberValue((int)PlayerStatIndex.Points),
                FG2Attempted = fg2.Attempted,
                FG2Made = fg2.Made,
                FG3Attempted = fg3.Attempted,
                FG3Made = fg3.Made,
                FTAttempted = ft.Attempted,
                FTMade = ft.Made,
                Game = game
            };
        }
    }
}
