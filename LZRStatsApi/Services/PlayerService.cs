using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LZRStatsApi.Models;
using LZRStatsApi.Repositories;
using LZRStatsApi.Repositories.Common;

namespace LZRStatsApi.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepo;


        public PlayerService(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await Task.Run(() => _playerRepo.GetAllAsync());
        }
    }
}
