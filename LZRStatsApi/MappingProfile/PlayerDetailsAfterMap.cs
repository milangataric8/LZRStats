using AutoMapper;
using LZRStatsApi.Models;
using LZRStatsApi.Models.Responses;
using LZRStatsApi.Services;
using System.Collections.Generic;

namespace LZRStatsApi.MappingProfile
{
    public class PlayerDetailsAfterMap : IMappingAction<Player, PlayerDetailsResponse>
    {
        private readonly IPlayerStatsCalculator _statsCalculator;
        private readonly ISeasonService _seasonService;
        public PlayerDetailsAfterMap(IPlayerStatsCalculator statsCalculator, ISeasonService seasonService)
        {
            _statsCalculator = statsCalculator;
            _seasonService = seasonService;
        }

        public async void Process(Player source, PlayerDetailsResponse destination, ResolutionContext context)
        {
            destination.GamesPlayed = _statsCalculator.GetGamesPlayed(source);
            destination.TeamName = source.Team.Name;
            destination.SeasonStats = new List<SeasonStatsResponse>();
            var seasons = await _seasonService.GetAll();
            foreach (var season in seasons)
            {
                int FG2A = _statsCalculator.GetTotalFG2Attempted(source);
                int FG3A = _statsCalculator.GetTotalFG3Attempted(source);
                int FG2M = _statsCalculator.GetTotalFG2Made(source);
                int FG3M = _statsCalculator.GetTotalFG3Made(source);
                var seasonStats = new SeasonStatsResponse // TODO query per season
                {
                    Value = season.Value,
                    APG = _statsCalculator.GetAssistsPerGame(source),
                    PPG = _statsCalculator.GetPointsPerGame(source),
                    RPG = _statsCalculator.GetReboundsPerGame(source),
                    MPG = _statsCalculator.GetMinutesPerGame(source),
                    BPG = _statsCalculator.GetBlocksPerGame(source),
                    SPG = _statsCalculator.GetStealsPerGame(source),
                    TPG = _statsCalculator.GetTurnoversPerGame(source),
                    FGPercentage = _statsCalculator.GetFGPercentage(source),
                    FG2Percentage = _statsCalculator.GetFG2Percentage(source),
                    FG3Percentage = _statsCalculator.GetFG3Percentage(source),
                    FTPercentage = _statsCalculator.GetFTPercentage(source),
                    FG2A = FG2A,
                    FG2M = FG2M,
                    FG3A = FG3A,
                    FG3M = FG3M,
                    FTA = _statsCalculator.GetTotalFTAttempted(source),
                    FTM = _statsCalculator.GetTotalFTMade(source),
                    FGA = FG2A + FG3A,
                    FGM = FG2M + FG3M,
                };
                destination.SeasonStats.Add(seasonStats);
            }

        }
    }
}
