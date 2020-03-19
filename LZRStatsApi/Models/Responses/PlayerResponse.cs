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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JerseyNumber { get; set; }
        public int GamesPlayed { get; set; }
    }
}
