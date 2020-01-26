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

        public User GetByLoginData(string username, string password)
        {
            return GetByAsync(x => x.Username.ToUpper() == password.ToUpper() && x.Password.Equals(password)).Result.SingleOrDefault(); //TODO async?
        }
    }
}
