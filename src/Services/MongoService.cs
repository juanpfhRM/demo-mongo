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
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoService()
        {
            var connectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
            var databaseName = Environment.GetEnvironmentVariable("MONGO_DATABASE_NAME");

            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
                throw new Exception("No se encontró la configuración de MongoDB en las variables de entorno.");

            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(databaseName);
        }

        public async Task TestConnectionAsync()
        {
            try
            {
                await _client.ListDatabaseNamesAsync();  

                var dbName = Environment.GetEnvironmentVariable("MONGO_DATABASE_NAME");
                var databaseNames = await _client.ListDatabaseNames().ToListAsync();

                if (!databaseNames.Contains(dbName))
                    throw new Exception($"La base de datos '{dbName}' no existe.");
            }
            catch (MongoException mex)
            {
                throw new Exception("No se pudo conectar a MongoDB. Verifica la cadena de conexión.", mex);
            }
            catch (TimeoutException tex)
            {
                throw new Exception("La conexión a MongoDB tardó demasiado. Verifica la cadena de conexión o si el servidor está disponible.", tex);
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
