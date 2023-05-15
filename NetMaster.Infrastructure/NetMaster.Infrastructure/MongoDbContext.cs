﻿using MongoDB.Driver;
using NetMaster.Domain.Models.DataModels;

namespace NetMaster.Infrastructure
{
    public class MongoDbContext
    {
        public MongoDbContext(string connectionString, string databaseName)
        {
            MongoClient client = new(connectionString);
            Database = client.GetDatabase(databaseName);
        }

        public IMongoDatabase Database { get; }

        public IMongoCollection<StorageInfoDataModel> RamInfos => Database.GetCollection<StorageInfoDataModel>("RamInfos");
        public IMongoCollection<ChocolateyInfoDataModel> ChocolateyInfos => Database.GetCollection<ChocolateyInfoDataModel>("ChocolateyInfos");
        public IMongoCollection<InstalledProgramsResponseModel> InstalledPrograms => Database.GetCollection<InstalledProgramsResponseModel>("InstalledPrograms");
        public IMongoCollection<StorageInfoDataModel> StorageInfos => Database.GetCollection<StorageInfoDataModel>("StorageInfos");
    }
}
