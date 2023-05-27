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

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? Timestamp { get; set; }

        public string? PSComputerName { get; set; }
    }
}