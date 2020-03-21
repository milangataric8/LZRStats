using LZRStatsApi.Data;
using LZRStatsApi.Models;
using LZRStatsApi.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Repositories
{
    public class GameRepository: RepositoryBase<Game>, IGameRepository
    {
        public readonly LzrStatsContext _context;
        public GameRepository(LzrStatsContext repositoryContext) : base(repositoryContext)
        {
            _context = repositoryContext;
        }
    }
}
