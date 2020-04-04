using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LZRStatsApi.Models
{
    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime PlayedOn { get; set; }
        public int Round { get; set; }
        public int MatchNumber { get; set; }
        public string Location { get; set; }
        public virtual ICollection<TeamGame> TeamGames { get; set; }
        public virtual ICollection<PlayerStats> PlayerStats { get; set; }
    }
}