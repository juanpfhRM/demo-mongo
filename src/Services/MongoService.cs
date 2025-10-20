using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Options;
using DemoMongo.Models;

namespace ApiMongoDemo.Services
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }

    public class MongoService
    {
        private readonly IMongoDatabase _database;
        private readonly MongoClient _client;

        public MongoService(IOptions<MongoSettings> settings)
        {
            _client = new MongoClient(settings.Value.ConnectionString);
            _database = _client.GetDatabase(settings.Value.DatabaseName);
        }

        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                await _database.RunCommandAsync((Command<MongoDB.Bson.BsonDocument>)"{ping:1}");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var collection = _database.GetCollection<Product>("products");
            var products = await collection.Find(_ => true).ToListAsync();
            return products;
        }

    }
}
