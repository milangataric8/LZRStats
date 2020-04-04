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
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _teamRepository.GetAllAsync();
        }

        public async Task<Team> GetById(int id)
        {
            return await Task.Run(() => _teamRepository.Find(id));
        }

        public async Task Create(Team team)
        {
            await _teamRepository.CreateAsync(team);
        }

        public async Task Update(Team team)
        {
            await _teamRepository.UpdateAsync(team);
        }

        public async Task Delete(Team team)
        {
            await _teamRepository.DeleteAsync(team);
        }

        public async Task<Team> GetOrCreateTeam(string teamName)
        {
            Team team = await _teamRepository.FindByNameAsync(teamName) ?? new Team { Name = teamName, TeamGames = new List<TeamGame>() };
            //if (team.Id == 0)
            //{
            //    await _teamRepository.CreateAsync(team);
            //    await _teamRepository.SaveChangesAsync();
            //}

            return team;
        }

        public async Task SaveChanges()
        {
            await _teamRepository.SaveChangesAsync();
        }
    }
}
