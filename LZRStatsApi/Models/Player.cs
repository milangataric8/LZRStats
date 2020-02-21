using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LZRStatsApi.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JerseyNumber { get; set; }
        public int GamesPlayed { get; set; }
        public virtual Team Team { get; set; }
        public virtual ICollection<PlayerStats> PlayerStats { get; set; }


        //TODO extract to PlayerStatsCalculator
        public double GetPointsPerGame()
        {
            return GetTotalPoints() / PlayerStats.Count;
        }

        public double GetFGPercentage()
        {
            var totalFG2Made = GetTotalFG2Made();
            var totalFG3Made = GetTotalFG2Made();
            var totalFG2Attempted = GetTotalFG2Attempted();
            var totalFG3Attempted = GetTotalFG3Attempted();
            var totalShotsMade = totalFG2Made + totalFG3Made;
            var totalShotsAttempted = totalFG2Attempted + totalFG3Attempted;

            return (totalShotsMade / totalShotsAttempted) * 100;
        }

        public int GetTotalPoints()
        {
            return SumStat(x => x.Points);
        }

        public int GetTotalFG2Made()
        {
            return SumStat(x => x.FG2Made);
        }

        public int GetTotalFG3Made()
        {
            return SumStat(x => x.FG3Made);
        }

        public int GetTotalFG2Attempted()
        {
            return SumStat(x => x.FG2Attempted);
        }

        public int GetTotalFG3Attempted()
        {
            return SumStat(x => x.FG3Attempted);
        }

        public int SumStat(Func<PlayerStats, int> func)
        {
            return PlayerStats.Sum(func);
        }
    }
}