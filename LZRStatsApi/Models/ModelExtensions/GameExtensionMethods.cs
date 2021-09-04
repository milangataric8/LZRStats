using LZRStatsApi.Models.Enums;

namespace LZRStatsApi.Models.ModelExtensions
{
    public static class GameExtensionMethods
    {
        public static bool IsPlayoffGame(this Game game)
        {
            return game.GameType == GameTypeEnum.Playoff;
        }
    }
}
