using LZRStatsApi.Models;
using System;
using System.Threading.Tasks;

namespace LZRStatsApi.Services
{
    public interface IGameService
    {
        Task<bool> IsGameImported(int roundNumber, int matchNumber, string teamName);
        Task AddOrUpdateAsync(Game game);
        Task<Game> FindGameAsync(DateTime playedOn, int round, int matchNumber);
    }
}
