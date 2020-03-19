using LZRStatsApi.Models;
using LZRStatsApi.Models.Responses;
using LZRStatsApi.Repositories.Common;
using System.Collections.Generic;

namespace LZRStatsApi.Repositories
{
    public interface IPlayerRepository : IRepositoryBase<Player>
    {

        void Add(Player player);
        IEnumerable<Player> GetAll();
        Player Find(int id);
        void Remove(int id);
        void Update(Player player);
    }
}
