using AutoMapper;
using LZRStatsApi.Models;
using LZRStatsApi.Models.Responses;

namespace LZRStatsApi.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Team, TeamResponse>().ReverseMap();
            CreateMap<Player, PlayerResponse>()
                .AfterMap<PlayerAfterMap>();
            CreateMap<PlayerResponse, Player>();
            CreateMap<Season, SeasonResponse>().ReverseMap();
        }
    }
}
