using LZRStatsApi.Data;
using LZRStatsApi.Models;
using LZRStatsApi.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Repositories
{
    public class SeasonRepository : RepositoryBase<Season>, ISeasonRepository
    {
        public SeasonRepository(LzrStatsContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
