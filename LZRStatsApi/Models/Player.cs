using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int JerseyNumber { get; set; }
        public string Team { get; set; }//TODO
    }
}
