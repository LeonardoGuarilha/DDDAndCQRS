using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using DDD.Infra.CrossCutting.Bus.Core.Data;
using DDD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly TournamentContext _tournamentContext;
        private readonly DbSet<Player> _dbSet;
        public IUnitOfWork UnitOfWork => _tournamentContext;

        public PlayerRepository(TournamentContext context)
        {
            _tournamentContext = context;
            _dbSet = _tournamentContext.Set<Player>();
        }
        
        public async Task<Player> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public void Add(Player player)
        {
            _dbSet.Add(player);
        }

        public void Update(Player player)
        {
            _dbSet.Update(player);
        }

        public void Remove(Player player)
        {
            _dbSet.Remove(player);
        }
        
        public void Dispose()
        {
            _tournamentContext.Dispose();
        }
    }
}