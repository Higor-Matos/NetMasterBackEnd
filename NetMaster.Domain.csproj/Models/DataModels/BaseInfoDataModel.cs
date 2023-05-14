//NetMaster.Domain/Models/DataModels/BaseInfoDataModel.cs
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NetMaster.Domain.Models.DataModels
{
    public abstract class BaseInfoDataModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? IpAddress { get; set; }
        public string? Timestamp { get; set; }
        public string? PSComputerName { get; set; }
    }
}

