using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Models.Dtos
{
    public class FieldGoal
    {
        public int Made { get; set; }
        public int Attempted { get; set; }

        public FieldGoal(int made, int attempted)
        {
            Made = made;
            Attempted = attempted;
        }
    }
}
