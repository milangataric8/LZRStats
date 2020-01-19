using LZRStatsApi.Models;
using LZRStatsApi.Repositories.Common;

namespace LZRStatsApi.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetByLoginData(string username, string password);
    }
}
