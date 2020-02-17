using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LZRStatsApi.Models;
using LZRStatsApi.Repositories;
using LZRStatsApi.Repositories.Common;

namespace LZRStatsApi.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public UserService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _repoWrapper.UserRepo.GetByLoginDataAsync(username, password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            user.Password = null;
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repoWrapper.UserRepo.GetAllAsync();
        }
    }
}
