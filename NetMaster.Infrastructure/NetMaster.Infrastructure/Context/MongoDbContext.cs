// NetMaster.Infrastructure.Context/MongoDbContext.cs
using MongoDB.Driver;

namespace NetMaster.Infrastructure.Context
{
    public class MongoDbContext
    {
        public MongoDbContext(string connectionString, string databaseName)
        {
            MongoClient client = new MongoClient(connectionString);
            Database = client.GetDatabase(databaseName);
        }
        public IMongoDatabase Database { get; }
    }
}