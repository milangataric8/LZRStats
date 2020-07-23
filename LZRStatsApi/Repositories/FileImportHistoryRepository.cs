using LZRStatsApi.Data;
using LZRStatsApi.Models;
using LZRStatsApi.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Repositories
{
    public class FileImportHistoryRepository : RepositoryBase<FileImportHistory>, IFileImportHistoryRepository
    {
        public readonly LzrStatsContext _context;
        public FileImportHistoryRepository(LzrStatsContext repositoryContext) : base(repositoryContext)
        {
            _context = repositoryContext;
        }
    }
}
