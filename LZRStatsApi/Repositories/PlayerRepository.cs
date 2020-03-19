using LZRStatsApi.Data;
using LZRStatsApi.Models;
using LZRStatsApi.Models.Responses;
using LZRStatsApi.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public readonly LzrStatsContext _context;
        public PlayerRepository(LzrStatsContext repositoryContext) : base(repositoryContext) 
        {
            _context = repositoryContext;
        }

        public void Add(Player player)
        {
            _context.Add(player);
            _context.SaveChanges();
        }

        public IEnumerable<Player> GetAll()
        {
            var result = _context.Player
                .ToList();
            return result;
        }

        public Player Find(int id)
        {
            return _context.Player
                .Single(x => x.Id == id);
        }

        public void Update(Player player)
        {
            var p = _context.Player.SingleOrDefault(r => r.Id == player.Id);
            if (p != null)
            {
                p.FirstName = player.FirstName;
                p.LastName = player.LastName;
                p.GamesPlayed = player.GamesPlayed;
                p.JerseyNumber = player.JerseyNumber;
            }
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var itemToRemove = _context.Player.SingleOrDefault(r => r.Id == id);
            if (itemToRemove != null)
            {
                _context.Player.Remove(itemToRemove);
            }
            _context.SaveChanges();
        }
    }
}
