using AutoMapper;
using LZRStatsApi.Models;
using LZRStatsApi.Models.Responses;
using LZRStatsApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.MappingProfile
{
    public class PlayerAfterMap : IMappingAction<Player, PlayerResponse>
    {
        private readonly IPlayerStatsCalculator _statsCalculator;
        public PlayerAfterMap(IPlayerStatsCalculator statsCalculator)
        {
            _statsCalculator = statsCalculator;
        }

        public void Process(Player source, PlayerResponse destination, ResolutionContext context)
        {
            destination.GamesPlayed = _statsCalculator.GetGamesPlayed(source);
            destination.APG = _statsCalculator.GetAssistsPerGame(source);
            destination.PPG = _statsCalculator.GetPointsPerGame(source);
            destination.RPG = _statsCalculator.GetReboundsPerGame(source);
            destination.MPG = _statsCalculator.GetMinutesPerGame(source);
            destination.BPG = _statsCalculator.GetBlocksPerGame(source);
            destination.SPG = _statsCalculator.GetStealsPerGame(source);
            destination.TPG = _statsCalculator.GetTurnoversPerGame(source);
            destination.FGPercentage = _statsCalculator.GetFGPercentage(source);
            destination.FG2Percentage = _statsCalculator.GetFG2Percentage(source);
            destination.FG3Percentage = _statsCalculator.GetFG3Percentage(source);
            destination.FTPercentage = _statsCalculator.GetFTPercentage(source);
            int fg2Made = _statsCalculator.GetTotalFG2Made(source);
            int fg3Made = _statsCalculator.GetTotalFG3Made(source);
            int fg2Missed = _statsCalculator.GetTotalFG2Attempted(source);
            int fg3Missed = _statsCalculator.GetTotalFG3Attempted(source);
            destination.FGA = fg2Made + fg3Made + fg2Missed + fg3Missed;
            destination.FGM = fg2Made + fg3Made;
            destination.FG2A = fg2Made + fg2Missed;
            destination.FG2M = fg2Made;
            destination.FG3A = fg3Made + fg3Missed;
            destination.FG3M = fg3Made;
            destination.FTA = _statsCalculator.GetTotalFTAttempted(source);
            destination.FTM = _statsCalculator.GetTotalFTMade(source);
            destination.TeamName = source.Team.Name;
        }
    }
}
