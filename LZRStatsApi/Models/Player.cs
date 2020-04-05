using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LZRStatsApi.Models
{
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JerseyNumber { get; set; }
        public virtual Team Team { get; set; }
        public virtual ICollection<PlayerStats> PlayerStats { get; set; }
    }
}