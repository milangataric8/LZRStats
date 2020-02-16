using AutoMapper;
using LZRStatsApi.Models;
using LZRStatsApi.Models.Dtos;
using LZRStatsApi.ViewModels;

namespace LZRStatsApi.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<Player, PlayerViewModel>().ReverseMap();
        }
    }
}
