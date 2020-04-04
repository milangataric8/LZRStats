using LZRStatsApi.Models;
using LZRStatsApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LZRStatsApi.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<IList<Game>> GetGamesByRoundAndGameNumberAsync(int roundNumber, int gameNumber)
        {
            IList<Game> games = await _gameRepository.GetByAsync(x => x.Round == roundNumber && x.MatchNumber == gameNumber);
            return games;
        }
    }
}
