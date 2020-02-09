using LZRStatsApi.Models;
using LZRStatsApi.Repositories;
using Ninject.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LZRStatsApi.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public TeamService(IRepositoryWrapper repositoryWrapper)
        {
            _repoWrapper = repositoryWrapper;
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await Task.Run(() => _repoWrapper.TeamRepo.GetAllAsync());
        }

        public async Task<Team> GetById(int id)
        {
            return await Task.Run(() => _repoWrapper.TeamRepo.Find(id));
        }

        public async Task Create(Team team)
        {
            await Task.Run(() =>_repoWrapper.TeamRepo.Add(team));
        }

        //public async Task Update(Team team)
        //{
        //    await Task.Run(() => _repoWrapper.TeamRepo.Update(team));
        //}

        public async Task Delete(int id)
        {
            await Task.Run(() => _repoWrapper.TeamRepo.Remove(id));
        }
    }
}
