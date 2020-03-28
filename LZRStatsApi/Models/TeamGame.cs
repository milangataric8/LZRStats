namespace LZRStatsApi.Models
{
    public class TeamGame
    {
        public int TeamId { get; set; }
        public int GameId { get; set; }
        public int PointsScored { get; set; }
        public int TotalRebounds { get; set; }
        public int OffensiveRebounds { get; set; }
        public int DefensiveRebounds { get; set; }
        public int Assists { get; set; }
        public int Turnovers { get; set; }
        public int Steals { get; set; }
        public int Blocks { get; set; }
        public virtual Team Team { get; set; }
        public virtual Game Game { get; set; }
    }
}