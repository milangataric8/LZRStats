using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Models.Responses
{
    public class PlayerResponse
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JerseyNumber { get; set; }
        public int GamesPlayed { get; set; }
        public decimal PPG { get; set; }
        public decimal RPG { get; set; }
        public decimal APG { get; set; }
        public decimal SPG { get; set; }
        public decimal BPG { get; set; }
        public decimal TPG { get; set; }
        public decimal FGPercentage { get; set; }
        public decimal FG2Percentage { get; set; }
        public decimal FG3Percentage { get; set; }
        public decimal FTPercentage { get; set; }
        public decimal MPG { get; set; }
        public int FGA { get; set; }
        public int FGM { get; set; }
        public int FG2A { get; set; }
        public int FG2M { get; set; }
        public int FG3A { get; set; }
        public int FG3M { get; set; }
        public int FTA { get; set; }
        public int FTM { get; set; }
    }
}
