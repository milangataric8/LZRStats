using LZRStatsApi.Models;
using LZRStatsApi.Repositories;
using System.Threading.Tasks;

namespace LZRStatsApi.Services
{
    public class FileImportHistoryService : IFileImportHistoryService
    {
        private readonly IFileImportHistoryRepository _fileImportHistoryRepository;
        public FileImportHistoryService(IFileImportHistoryRepository fileImportHistoryRepository)
        {
            _fileImportHistoryRepository = fileImportHistoryRepository;
        }

        public async Task AddOrUpdateAsync(FileImportHistory file)
        {
            await _fileImportHistoryRepository.AddOrUpdateAsync(file);
            await _fileImportHistoryRepository.SaveChangesAsync();
        }
    }
}
