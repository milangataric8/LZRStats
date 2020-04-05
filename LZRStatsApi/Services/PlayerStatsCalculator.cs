using LZRStatsApi.Models;
using System;
using System.Linq;

namespace LZRStatsApi.Services
{
    public class PlayerStatsCalculator : IPlayerStatsCalculator
    {
        public decimal GetPointsPerGame(Player player)
        {
            return GetTotalPoints(player) / player.PlayerStats.Count;
        }

        public decimal GetFGPercentage(Player player)
        {
            var totalFG2Made = GetTotalFG2Made(player);
            var totalFG3Made = GetTotalFG2Made(player);
            var totalFG2Attempted = GetTotalFG2Attempted(player);
            var totalFG3Attempted = GetTotalFG3Attempted(player);
            var totalShotsMade = totalFG2Made + totalFG3Made;
            var totalShotsAttempted = totalFG2Attempted + totalFG3Attempted;

            return (totalShotsMade / totalShotsAttempted) * 100;
        }

        public decimal GetFG3Percentage(Player player)
        {
            var totalFG3Made = GetTotalFG2Made(player);
            var totalFG3Attempted = GetTotalFG3Attempted(player);

            return (totalFG3Made / totalFG3Attempted) * 100;
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

        public int GetTotalFG2Attempted(Player player)
        {
            return player.PlayerStats.Sum(x => x.FG2Attempted);
        }

        public int GetTotalFG3Attempted(Player player)
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
            return player.PlayerStats.Sum(stat) / player.PlayerStats.Count;
        }
    }
}
