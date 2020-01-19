using AutoMapper;
using LZRStatsApi.Models;
using LZRStatsApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Team, TeamDto>().ReverseMap();
        }
    }
}
