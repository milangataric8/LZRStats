using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using LZRStatsApi.Helpers;
using LZRStatsApi.Models;
using LZRStatsApi.Repositories;
using LZRStatsApi.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Importers
{
    public class StatsImporter : IStatsImporter
    {
        private readonly IPlayerRepository _playerRepo;
        private readonly IGameRepository _gameRepo;
        private readonly ITeamService _teamService;
        private readonly ITeamGameRepository _teamGameRepo;
        public StatsImporter(IPlayerRepository playerRepo, IGameRepository gameRepository, ITeamService teamService, ITeamGameRepository teamGameRepository)
        {
            _playerRepo = playerRepo;
            _gameRepo = gameRepository;
            _teamService = teamService;
            _teamGameRepo = teamGameRepository;
        }

        public async Task ExtractFromFile(string filePath, string fileName)
        {
            var data = filePath.GetFileData();
            var teamName = data.GetTeamName();
            Team team = await _teamService.GetOrCreateTeam(teamName);
            Game game = await GetOrCreateGame(fileName, data);
            team.Players = await data.ExtractPlayers(team.Id, game, _playerRepo);
            TeamGame teamGame = ExtractTeamGameData(data);
            teamGame.Team = team;
            teamGame.Game = game;
            game.TeamGames.Add(teamGame);

            await _gameRepo.CreateAsync(game);
            await _teamService.Create(team);
            await _teamService.SaveChanges();

            //await _teamGameRepo.SaveChangesAsync();
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
            Game game = new Game
            {
                PlayedOn = data.GetDatePlayed(),
                Round = int.Parse(matchData[0]),
                MatchNumber = int.Parse(matchData[1]),
                TeamGames = new List<TeamGame>()
            };
            var dbGame = await _gameRepo.GetByAsync(x => x.PlayedOn == game.PlayedOn && x.Round == game.Round && x.MatchNumber == game.MatchNumber);
            //if(dbGame.Count == 0)
            //{
            //    await _gameRepo.CreateAsync(game);
            //    await _gameRepo.SaveChangesAsync();
            //}
            return dbGame?.SingleOrDefault() ?? game;
        }



        private async Task ImportData()
        {

        }

    }
}

