using LZRStatsApi.Models;
using LZRStatsApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;
        public SeasonService(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task<IEnumerable<Season>> GetAll()
        {
            return await _seasonRepository.GetAllAsync();
        }
    }
}
