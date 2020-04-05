using AutoMapper;
using LZRStatsApi.Models;
using LZRStatsApi.Models.Dtos;
using LZRStatsApi.Models.Responses;
using LZRStatsApi.Services;
using LZRStatsApi.ViewModels;

namespace LZRStatsApi.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<Player, PlayerResponse>()
                .AfterMap<PlayerAfterMap>();
            CreateMap<PlayerResponse, Player>();
        }

        public class PlayerAfterMap : IMappingAction<Player, PlayerResponse>
        {
            private readonly IPlayerStatsCalculator _statsCalculator;
            public PlayerAfterMap(IPlayerStatsCalculator statsCalculator)
            {
                _statsCalculator = statsCalculator;
            }

            public void Process(Player source, PlayerResponse destination, ResolutionContext context)
            {
                destination.APG = _statsCalculator.GetAssistsPerGame(source);
                destination.PPG = _statsCalculator.GetPointsPerGame(source);
                destination.APG = _statsCalculator.GetMinutesPerGame(source);
                destination.APG = _statsCalculator.GetBlocksPerGame(source);
                destination.APG = _statsCalculator.GetStealsPerGame(source);
                destination.APG = _statsCalculator.GetTurnoversPerGame(source);
                destination.APG = _statsCalculator.GetFGPercentage(source);
                destination.APG = _statsCalculator.GetFG3Percentage(source);
            }
        }
    }
}
