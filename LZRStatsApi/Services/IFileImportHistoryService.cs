using LZRStatsApi.Models;
using System.Threading.Tasks;

namespace LZRStatsApi.Services
{
    public interface IFileImportHistoryService
    {
        Task SaveFile(FileImportHistory file);
    }
}
