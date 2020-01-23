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

        IEnumerable<Team> ITeamRepository.GetAll()
        {
            var res = _context.Teams.Select(t => new Team())
                                    .ToList();
            return res;
        }

        public Team Find(int id)
        {
            var res = _context.Teams.Single(t => t.Id == id);
            return res;
        }

        public void Remove(int id)
        {
            var teamToRemove = _context.Teams.SingleOrDefault(t => t.Id == id);
            if (teamToRemove != null)
            {
                _context.Teams.Remove(teamToRemove);
            }
            _context.SaveChanges();
        }

        public void Update(Team team)
        {
            var res = _context.Teams.SingleOrDefault(t => t.Id == team.Id);
            if (res != null)
            {
                res.Name = team.Name;
                res.Wins = team.Wins;
                res.Loses = team.Loses;
            }
            _context.SaveChanges();
        }
    }
}
