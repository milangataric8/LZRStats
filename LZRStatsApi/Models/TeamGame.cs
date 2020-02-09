namespace LZRStatsApi.Models
{
    public class TeamGame
    {
        public int TeamId { get; set; }
        public int GameId { get; set; }
        public int PointsScored { get; set; }
        public virtual Team Team { get; set; }
        public virtual Game Game { get; set; }
    }
}