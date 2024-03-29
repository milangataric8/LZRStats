﻿using LZRStatsApi.Models.Enums;

namespace LZRStatsApi.Helpers
{
    public class GameDetails
    {
        public string SeasonId { get; set; }
        public string League { get; set; } = LeagueEnum.A.ToString();
        public GameTypeEnum GameType { get; set; } = GameTypeEnum.Regular;
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}
