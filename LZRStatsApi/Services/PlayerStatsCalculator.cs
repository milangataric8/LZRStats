using LZRStatsApi.Models;
using System;
using System.Linq;

namespace LZRStatsApi.Services
{
    public class PlayerStatsCalculator : IPlayerStatsCalculator
    {
        public decimal GetPointsPerGame(Player player)
        {
            return CalculatePerGameStat(player, x => x.Points);
        }

        public decimal GetFGPercentage(Player player)
        {
            var fg2p = GetFG2Percentage(player);
            var fg3p = GetFG3Percentage(player);

            return Math.Round((decimal)(fg2p + fg3p) / 2, 1);
        }

        public decimal GetFG3Percentage(Player player)
        {
            var totalFG3Made = GetTotalFG3Made(player);
            var totalFG3Missed = GetTotalFG3Missed(player);

            return CalculateShootingPercentage(totalFG3Made, totalFG3Missed + totalFG3Made);
        }

        public decimal GetFG2Percentage(Player player)
        {
            var totalFG2Made = GetTotalFG2Made(player);
            var totalFG2Missed = GetTotalFG2Missed(player);

            return CalculateShootingPercentage(totalFG2Made, totalFG2Missed + totalFG2Made);
        }


        private decimal CalculateShootingPercentage(int made, int attempted)
        {
            if (attempted == 0) return 0.0m;
            decimal percentage = ((decimal)made / (decimal)(attempted)) * 100;

            return Math.Round(percentage, 1);
        }

        public decimal GetFTPercentage(Player player)
        {
            var totalFTMade = GetTotalFTMade(player);
            var totalFTAttempted = GetTotalFTAttempted(player);

            return CalculateShootingPercentage(totalFTMade, totalFTAttempted);
        }

        public int GetTotalFTMade(Player player)
        {
            return player.PlayerStats.Sum(x => x.FTMade);
        }

        public int GetTotalFTAttempted(Player player)
        {
            return player.PlayerStats.Sum(x => x.FTAttempted);
        }


        public int GetTotalPoints(Player player)
        {
            return player.PlayerStats.Sum(x => x.Points);
        }

        public int GetTotalFG2Made(Player player)
        {
            return player.PlayerStats.Sum(x => x.FG2Made);
        }

        public int GetTotalFG3Made(Player player)
        {
            return player.PlayerStats.Sum(x => x.FG3Made);
        }

        public int GetTotalFG2Missed(Player player)
        {
            return player.PlayerStats.Sum(x => x.FG2Attempted);
        }

        public int GetTotalFG3Missed(Player player)
        {
            return player.PlayerStats.Sum(x => x.FG3Attempted);
        }

        public decimal GetAssistsPerGame(Player player)
        {
            return CalculatePerGameStat(player, x => x.Assists);
        }

        public decimal GetReboundsPerGame(Player player)
        {
            return CalculatePerGameStat(player, x => x.TotalRebounds);
        }

        public decimal GetStealsPerGame(Player player)
        {
            return CalculatePerGameStat(player, x => x.Steals);
        }

        public decimal GetBlocksPerGame(Player player)
        {
            return CalculatePerGameStat(player, x => x.Blocks);
        }

        public decimal GetTurnoversPerGame(Player player)
        {
            return CalculatePerGameStat(player, x => x.Turnovers);
        }

        public decimal GetMinutesPerGame(Player player)
        {
            return CalculatePerGameStat(player, x => x.MinutesPlayed);
        }

        private decimal CalculatePerGameStat(Player player, Func<PlayerStats, decimal> stat)
        {
            int gamesPlayed = GetGamesPlayed(player);
            return gamesPlayed == 0 ? 0.0m : Math.Round(player.PlayerStats.Sum(stat) / gamesPlayed, 1);
        }

        public int GetGamesPlayed(Player source)
        {
            return source.PlayerStats.Where(x => x.MinutesPlayed > 0).ToList().Count;
        }
    }
}
