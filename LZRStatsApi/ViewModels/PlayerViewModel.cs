using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.ViewModels
{
    public class PlayerViewModel
    {
        public int Id { get; set; }
        public int TeamId { get; set; }

        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }
        [Required]
        public int JerseyNumber { get; set; }
        public int GamesPlayed { get; set; }
    }
}
