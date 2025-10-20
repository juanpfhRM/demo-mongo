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

        public MongoService()
        {
            var connectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
            var databaseName = Environment.GetEnvironmentVariable("MONGO_DATABASE_NAME");

            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
                throw new Exception("No se encontró la configuración de MongoDB en las variables de entorno.");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
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
