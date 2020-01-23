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
        Team GetById(int id);
        void Create(Team team);
        void Update(Team team);
        void Delete(int id);
    }
}
