using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Models.Dtos
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
    }
}
