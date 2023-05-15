// NetMaster.Repository/BaseRepository.cs
using MongoDB.Driver;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;
using NetMaster.Repository.Interfaces;

namespace NetMaster.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseInfoDataModel
    {
        private readonly IMongoCollection<T> _collection;

        public BaseRepository(MongoDbContext dbContext, string collectionName)
        {
            _collection = dbContext.Database.GetCollection<T>(collectionName);
        }

        public async Task<T> GetMostRecentByComputerNameAsync(string computerName)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("PSComputerName", computerName);
            SortDefinition<T> sort = Builders<T>.Sort.Descending("Timestamp");
            IAsyncCursor<T> result = await _collection.FindAsync(filter, new FindOptions<T, T> { Sort = sort });
            return await result.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IAsyncCursor<T> result = await _collection.FindAsync(Builders<T>.Filter.Empty);
            return await result.ToListAsync();
        }

        public async Task<T> GetByComputerNameAsync(string computerName)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("PSComputerName", computerName);
            IAsyncCursor<T> result = await _collection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }

        public async Task InsertAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("Id", entity.Id);
            _ = await _collection.ReplaceOneAsync(filter, entity);
        }
    }
}
