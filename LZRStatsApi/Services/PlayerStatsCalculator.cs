using LZRStatsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Services
{
    public class PlayerStatsCalculator:IPlayerStatsCalculator
    {
        public double GetPointsPerGame(Player player)
        {
            return GetTotalPoints(player) / player.PlayerStats.Count;
        }

        public double GetFGPercentage(Player player)
        {
            var totalFG2Made = GetTotalFG2Made(player);
            var totalFG3Made = GetTotalFG2Made(player);
            var totalFG2Attempted = GetTotalFG2Attempted(player);
            var totalFG3Attempted = GetTotalFG3Attempted(player);
            var totalShotsMade = totalFG2Made + totalFG3Made;
            var totalShotsAttempted = totalFG2Attempted + totalFG3Attempted;

            return (totalShotsMade / totalShotsAttempted) * 100;
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
    }
}
