using LZRStatsApi.Models.Enums;
using System;

namespace LZRStatsApi.Helpers
{
    public class FileDetails
    {
        public string Season { get; set; }
        public string League { get; set; } = LeagueEnum.A.ToString();
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}
