using LZRStatsApi.Helpers;
using LZRStatsApi.Models;
using LZRStatsApi.Repositories;
using LZRStatsApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LZRStatsApi.Importers
{
    public class StatsImporter : IStatsImporter
    {
        private readonly IPlayerRepository _playerRepo;
        private readonly IGameService _gameService;
        private readonly ITeamService _teamService;
        private readonly ITeamGameRepository _teamGameRepo;
        public StatsImporter(IPlayerRepository playerRepo, IGameService gameService, ITeamService teamService, ITeamGameRepository teamGameRepository)
        {
            _playerRepo = playerRepo;
            _gameService = gameService;
            _teamService = teamService;
            _teamGameRepo = teamGameRepository;
        }

        public async Task ImportAsync(GameDetails fileDetails)
        {
            var data = fileDetails.FilePath.GetFileData();
            var teamName = data.GetTeamName();
            Team team = await _teamService.GetOrCreateTeam(teamName);
            Game game = await GetOrCreateGame(fileDetails.FileName, data);
            game.SeasonId = int.Parse(fileDetails.SeasonId);
            game.League = fileDetails.League;
            await data.ExtractPlayers(team, game, _playerRepo);// TODO refactor this
            TeamGame teamGame = ExtractTeamGameData(data);
            teamGame.Team = team;
            teamGame.Game = game;
            game.TeamGames.Add(teamGame);

            await _gameService.AddOrUpdateAsync(game);
            await _teamService.AddOrUpdateAsync(team);
            await _teamService.SaveChangesAsync();
        }

        //var opposingTeamName = data.GetOpposingTeamName();
        //var totalFG = data.GetFGStatValue((int)FGStatIndex.TotalFG);
        //var totalFG2 = data.GetFGStatValue((int)FGStatIndex.TotalFG2);
        //var totalFG3 = data.GetFGStatValue((int)FGStatIndex.TotalFG3);
        //var totalFT = data.GetFGStatValue((int)FGStatIndex.TotalFT);

        private TeamGame ExtractTeamGameData(List<string> data)
        {
            var teamGame = new TeamGame
            {
                Assists = data.GetNumberValue((int)StatIndex.TotalAssists),
                Blocks = data.GetNumberValue((int)StatIndex.TotalBlocks),
                DefensiveRebounds = data.GetNumberValue((int)StatIndex.TeamDefensiveRebounds),
                OffensiveRebounds = data.GetNumberValue((int)StatIndex.TeamOffensiveRebounds),
                PointsScored = data.GetNumberValue((int)StatIndex.TotalPoints),
                Steals = data.GetNumberValue((int)StatIndex.TotalSteals),
                TotalRebounds = data.GetNumberValue((int)StatIndex.TotalRebounds),
                Turnovers = data.GetNumberValue((int)StatIndex.TotalTurnovers)
            };

            return teamGame;
        }

        private async Task<Game> GetOrCreateGame(string fileName, List<string> data)
        {
            fileName = fileName.ReplaceBadMinusCharacter();
            var matchData = fileName.Split('-');
            //TODO extract from here and FileValidateAttr to one method
            DateTime playedOn = data.GetDatePlayed();
            int roundNo = int.Parse(matchData[0]);
            int matchNo = int.Parse(matchData[1]);
            Game game = await _gameService.FindGameAsync(playedOn, roundNo, matchNo) ??
            new Game
            {
                PlayedOn = playedOn,
                Round = roundNo,
                MatchNumber = matchNo,
                TeamGames = new List<TeamGame>()
            };

            return game;
        }



        private async Task ImportData()
        {

        }

    }
}

