using LZRStatsApi.Models.Enums;

namespace LZRStatsApi.Helpers
{
    public class FilesImportSettings
    {
        public string SeasonId { get; set; }
        public string League { get; set; } = LeagueEnum.A.ToString();
    }
}
