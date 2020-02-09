using LZRStatsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAll();
        Task<Team> GetById(int id);
        Task Create(Team team);
        //Task Update(Team team);
        Task Delete(int id);
    }
}
