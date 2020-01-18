using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LZRStatsApi.Models;

namespace LZRStatsApi.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }
}
