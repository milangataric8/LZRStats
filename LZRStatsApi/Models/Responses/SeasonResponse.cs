using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Models.Responses
{
    public class SeasonResponse
    {
        public int Id { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Value
        {
            get
            {
                return String.Join('/', StartYear, EndYear);
            }
        }
    }
}
