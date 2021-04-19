using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DDD.Infra.Data.Repositories
{
    public class PlayerRepositoryMongoDb : IPlayerRepositoryMongoDb
    {
        private readonly IMongoDatabase Db;

        public PlayerRepositoryMongoDb(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetSection("MongoDb:Connection").Value);
            Db = client.GetDatabase("Tournament");
        }
        
        public void Add(Player player)
        {
            var collection = Db.GetCollection<Player>("Players");
            collection.InsertOne(player);
        }
    }
}