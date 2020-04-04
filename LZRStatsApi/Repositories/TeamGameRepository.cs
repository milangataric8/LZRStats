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
    public class TeamGameRepository : RepositoryBase<TeamGame>, ITeamGameRepository
    {
        LzrStatsContext _context;
        public TeamGameRepository(LzrStatsContext repositoryContext) : base(repositoryContext)
        {
            _context = repositoryContext;
        }

        public async Task AddGameAsync(Game game)
        {
            throw new NotImplementedException();
        }

        public async Task AddTeamAsync(Team team)
        {
            throw new NotImplementedException();
        }
    }
}
