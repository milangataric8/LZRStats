using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LZRStatsApi.Models
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<TeamGame> TeamGames { get; set; }

        public void AddWin()
        {
            Wins++;
        }

        public void AddLoss()
        {
            Losses++;
        }
    }
}