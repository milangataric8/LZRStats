using LZRStatsApi.Models;
using LZRStatsApi.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LZRStatsApi.Repositories
{
    public interface ITeamRepository : IRepositoryBase<Team>
    {
        void Add(Team team);
        Team Find(int id);
        void Remove(int id);
        Task<Team> FindByNameAsync(string teamName);
        IEnumerable<Team> GetAll();

    }
}
