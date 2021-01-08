using LZRStatsApi.Models;

namespace LZRStatsApi.Services
{
    public interface IPlayerStatsCalculator
    {
        public decimal GetPointsPerGame(Player player);
        public decimal GetFGPercentage(Player player);
        public decimal GetFG3Percentage(Player player);
        public decimal GetFG2Percentage(Player player);
        public decimal GetFTPercentage(Player player);
        public int GetTotalPoints(Player player);
        public int GetTotalFG2Made(Player player);
        public int GetTotalFG3Made(Player player);
        public int GetTotalFG2Attempted(Player player);
        public int GetTotalFG3Attempted(Player player);
        public int GetTotalFTMade(Player player);
        public int GetTotalFTAttempted(Player player);
        public decimal GetAssistsPerGame(Player player);
        public decimal GetReboundsPerGame(Player player);
        public decimal GetStealsPerGame(Player player);
        public decimal GetBlocksPerGame(Player player);
        public decimal GetTurnoversPerGame(Player player);
        public decimal GetMinutesPerGame(Player player);
        public int GetGamesPlayed(Player source);
    }
}
