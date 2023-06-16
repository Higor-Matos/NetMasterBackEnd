// NetMaster.Infrastructure.Context/MongoDbContext.cs
using MongoDB.Driver;
using NetMaster.Infrastructure.Interface;

namespace NetMaster.Infrastructure.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        public MongoDbContext(string connectionString, string databaseName)
        {
            MongoClient client = new(connectionString);
            Database = client.GetDatabase(databaseName);
        }
        public IMongoDatabase Database { get; }
    }
}