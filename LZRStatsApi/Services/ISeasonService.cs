using LZRStatsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Services
{
    public interface ISeasonService
    {
        Task<IEnumerable<Season>> GetAll();
    }
}
