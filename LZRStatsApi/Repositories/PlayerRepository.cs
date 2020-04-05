using LZRStatsApi.Data;
using LZRStatsApi.Models;
using LZRStatsApi.Models.Responses;
using LZRStatsApi.Repositories.Common;
using Microsoft.EntityFrameworkCore;
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
            _context.Player.Update(player);
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

        public async Task<Player> Find(int teamId, string lastName, string firstName, int jerseyNo)
        {
            return await Task.Run(() =>
            {
                return _context.Player
                    .SingleOrDefault(x => x.TeamId == teamId && x.LastName == lastName && x.FirstName == firstName && x.JerseyNumber == jerseyNo);
            });
        }
    }
}
