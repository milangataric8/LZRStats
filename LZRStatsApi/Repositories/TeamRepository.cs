using LZRStatsApi.Data;
using LZRStatsApi.Models;
using LZRStatsApi.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LZRStatsApi.Repositories
{
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        LzrStatsContext _context;
        public TeamRepository(LzrStatsContext repositoryContext) : base(repositoryContext)
        {
            _context = repositoryContext;
        }

        public void Add(Team team)
        {
            _context.Add(team);
            _context.SaveChanges();
        }


        public Team Find(int id)
        {
            var res = _context.Team.Single(t => t.Id == id);
            return res;
        }

        public async Task<Team> FindByNameAsync(string teamName)
        {
            return await _context.Team.SingleOrDefaultAsync(t => t.Name == teamName);
        }

        public void Remove(int id)
        {
            var teamToRemove = _context.Team.SingleOrDefault(t => t.Id == id);
            if (teamToRemove != null)
            {
                _context.Team.Remove(teamToRemove);
            }
            _context.SaveChanges();
        }
    }
}
