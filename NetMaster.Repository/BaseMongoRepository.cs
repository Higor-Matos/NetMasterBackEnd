//NetMaster.Repository/BaseMongoRepository.cs
using MongoDB.Driver;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Infrastructure;
using NetMaster.Repository.Interfaces.BaseCommand;

namespace NetMaster.Repository
{
    public class BaseMongoRepository<T> : IBaseRepository<T> where T : BaseInfoDataModel
    {
        protected readonly IMongoCollection<T> _mongoCollection;

        public BaseMongoRepository(MongoDbContext dbContext, string collectionName)
        {
            _mongoCollection = dbContext.Database.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _mongoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetByComputerNameAsync(string computerName)
        {
            return await _mongoCollection.Find(Builders<T>.Filter.Eq("PSComputerName", computerName)).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(T entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", entity.Id);
            _ = await _mongoCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task<RepositoryResultModel<T>> GetMostRecentByComputerNameAsync(string computerName)
        {
            T entity = await GetMostRecentEntityByComputerName(computerName);

            return new RepositoryResultModel<T>
            {
                Data = entity,
                Success = entity != null,
                Message = entity != null ? "" : $"No records found for computer name: {computerName}"
            };
        }

        private async Task<T> GetMostRecentEntityByComputerName(string computerName)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("PSComputerName", computerName);
            SortDefinition<T> sort = Builders<T>.Sort.Descending(x => x.Timestamp);
            IAsyncCursor<T> result = await _mongoCollection.FindAsync(filter, new FindOptions<T, T> { Sort = sort });

            return await result.FirstOrDefaultAsync();
        }

    }
}
