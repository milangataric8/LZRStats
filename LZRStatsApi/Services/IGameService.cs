using LZRStatsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LZRStatsApi.Services
{
    public interface IGameService
    {
        Task<IList<Game>> GetGamesByRoundAndGameNumberAsync(int roundNumber, int matchNumber);
    }
}
