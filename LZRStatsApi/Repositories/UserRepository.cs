using LZRStatsApi.Data;
using LZRStatsApi.Models;
using LZRStatsApi.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(LzrStatsContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<User> GetByLoginDataAsync(string username, string password)
        {
             return await GetSingleByAsync(x => x.Username.ToUpper() == password.ToUpper() && x.Password.Equals(password));
        }
    }
}
