using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using LZRStatsApi.Helpers;
using LZRStatsApi.Models;
using LZRStatsApi.Repositories;
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
        private readonly ITeamRepository _teamRepo;
        private readonly ITeamGameRepository _teamGameRepo;
        public StatsImporter(IPlayerRepository playerRepo, IGameRepository gameRepository, ITeamRepository teamRepository, ITeamGameRepository teamGameRepository)
        {
            _playerRepo = playerRepo;
            _gameRepo = gameRepository;
            _teamRepo = teamRepository;
            _teamRepo = teamRepository;
            _teamGameRepo = teamGameRepository;
        }

        public async Task ExtractFromFile(string filePath, string fileName)
        {
            var data = filePath.GetFileData();
            var teamName = data.GetTeamName();
            Team team = await GetOrCreateTeam(teamName);
            Game game = await GetOrCreateGame(fileName, data);
            //var opposingTeamName = data.GetOpposingTeamName();
            //var totalFG = data.GetFGStatValue((int)FGStatIndex.TotalFG);
            //var totalFG2 = data.GetFGStatValue((int)FGStatIndex.TotalFG2);
            //var totalFG3 = data.GetFGStatValue((int)FGStatIndex.TotalFG3);
            //var totalFT = data.GetFGStatValue((int)FGStatIndex.TotalFT);

            TeamGame teamGame = await ExtractTeamGameData(data, team, game);

            var players = data.ExtractPlayers();
            foreach (var p in players)
            {
                p.Team = team;
                var dbPlayer = await _playerRepo.GetSingleByAsync(x => x.FirstName == p.FirstName && x.LastName == p.LastName && x.JerseyNumber == p.JerseyNumber && x.Team == p.Team);
                if(dbPlayer == null)
                {
                    await _playerRepo.CreateAsync(p);
                }
            }
            await _playerRepo.SaveChangesAsync();
        }

        private async Task<TeamGame> ExtractTeamGameData(List<string> data, Team team, Game game)
        {
            var teamGame = new TeamGame
            {
                Assists = data.GetNumberValue((int)StatIndex.TotalAssists),
                Blocks = data.GetNumberValue((int)StatIndex.TotalBlocks),
                DefensiveRebounds = data.GetNumberValue((int)StatIndex.TeamDefensiveRebounds),
                OffensiveRebounds = data.GetNumberValue((int)StatIndex.TeamOffensiveRebounds),
                Game = game,
                PointsScored = data.GetNumberValue((int)StatIndex.TotalPoints),
                Steals = data.GetNumberValue((int)StatIndex.TotalSteals),
                Team = team,
                TotalRebounds = data.GetNumberValue((int)StatIndex.TotalRebounds),
                Turnovers = data.GetNumberValue((int)StatIndex.TotalTurnovers)
            };

            await _teamGameRepo.CreateAsync(teamGame);
            await _teamGameRepo.SaveChangesAsync();

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
                MatchNumber = int.Parse(matchData[1])
            };
            var dbGame = await _gameRepo.GetByAsync(x => x.PlayedOn == game.PlayedOn && x.Round == game.Round && x.MatchNumber == game.MatchNumber);
            if(dbGame.Count == 0)
            {
                await _gameRepo.CreateAsync(game);
                await _gameRepo.SaveChangesAsync();
            }
            return dbGame?.SingleOrDefault() ?? game;
        }

        private async Task<Team> GetOrCreateTeam(string teamName)
        {
            Team team = await _teamRepo.FindByNameAsync(teamName) ?? new Team { Name = teamName, TeamGames = new List<TeamGame>() };
            if (team.Id == 0)
            {
                await _teamRepo.CreateAsync(team);
                await _teamRepo.SaveChangesAsync();
            }

            return team;
        }

        private async Task ImportData()
        {

        }

    }
}

