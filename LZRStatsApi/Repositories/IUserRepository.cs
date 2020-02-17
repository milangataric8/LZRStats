using LZRStatsApi.Models;
using LZRStatsApi.Repositories.Common;
using System.Threading.Tasks;

namespace LZRStatsApi.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByLoginDataAsync(string username, string password);
    }
}
