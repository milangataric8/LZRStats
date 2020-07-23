using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Models
{
    public class FileImportHistory
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime DateImported { get; set; }
    }
}
