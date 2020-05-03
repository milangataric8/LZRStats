using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Models
{
    public class Season
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public virtual ICollection<Game> Games { get; set; }
    }
}
