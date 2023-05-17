// NetMaster.Infrastructure.Context/MongoDbContext.cs
using MongoDB.Driver;

namespace NetMaster.Infrastructure.Context
{
    public interface IMongoDbContext
    {
        IMongoDatabase Database { get; }
    }
}