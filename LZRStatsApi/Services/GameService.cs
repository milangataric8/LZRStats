using LZRStatsApi.Models;
using LZRStatsApi.Repositories;
using System;
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

        public async Task AddOrUpdateAsync(Game game)
        {
            await _gameRepository.AddOrUpdateAsync(game);
        }

        public async Task<Game> FindGameAsync(DateTime playedOn, int round, int matchNumber)
        {
            var game = await _gameRepository.GetSingleByAsync(x => x.PlayedOn == playedOn && x.Round == round && x.MatchNumber == matchNumber);
            
            return game;
        }
    }
}
