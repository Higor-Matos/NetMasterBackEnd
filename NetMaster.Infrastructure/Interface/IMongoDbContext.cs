// NetMaster.Infrastructure.Context/MongoDbContext.cs
using MongoDB.Driver;

namespace NetMaster.Infrastructure.Interface
{
    public interface IMongoDbContext
    {
        IMongoDatabase Database { get; }
    }
}