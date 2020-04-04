using LZRStatsApi.Models;
using LZRStatsApi.Repositories;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> IsGameImported(int roundNumber, int gameNumber, string teamName)
        {
            IList<Game> games = await _gameRepository.GetByAsync(x => x.Round == roundNumber && x.MatchNumber == gameNumber
             && x.TeamGames.Any(t => t.Team.Name.ToLower() == teamName.ToLower()));
            return games.Any();
        }
    }
}
