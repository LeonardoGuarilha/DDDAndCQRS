using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Domain.Models;
using DDD.Infra.CrossCutting.Bus.Core.Data;

namespace DDD.Domain.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<Player> GetById(Guid id);
        Task<IEnumerable<Player>> GetAll();

        void Add(Player player);
        void Update(Player player);
        void Remove(Player player);
    }
}