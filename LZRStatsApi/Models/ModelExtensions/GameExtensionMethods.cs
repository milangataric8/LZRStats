using LZRStatsApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Models.ModelExtensions
{
    public static class GameExtensionMethods
    {
        public static bool IsPlayoffGame(this Game game)
        {
            return game.GameType == (int)GameType.Playoff;
        }
    }
}
