using DDD.Domain.Models;

namespace DDD.Domain.Interfaces
{
    public interface IPlayerRepositoryMongoDb
    {
        void Add(Player player);
    }
}