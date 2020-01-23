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
            return await Task.Run(() => _repoWrapper.TeamRepo.GetAll());
        }

        public Team GetById(int id)
        {
            return _repoWrapper.TeamRepo.Find(id);
        }

        public async void Create(Team team)
        {
            _repoWrapper.TeamRepo.Add(team);
        }

        public async void Update(Team team)
        {
            _repoWrapper.TeamRepo.Update(team);
        }

        public async void Delete(int id)
        {
            _repoWrapper.TeamRepo.Remove(id);
        }
    }
}
