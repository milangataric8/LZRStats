using LZRStatsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LZRStatsApi.Services
{
    public interface IGameService
    {
        Task<bool> IsGameImported(int roundNumber, int matchNumber, string teamName);
    }
}
