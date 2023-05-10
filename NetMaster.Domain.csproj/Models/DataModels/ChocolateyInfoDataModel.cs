// NetMaster.Domain/Models/DataModels/ChocolateyInfoDataModel.cs

using MongoDB.Bson.Serialization.Attributes;

namespace NetMaster.Domain.Models.DataModels
{
    public class ChocolateyInfoDataModel : BaseInfoDataModel
    {
        [BsonElement("ChocolateyVersion")]
        public string? ChocolateyVersion { get; set; }
        [BsonElement("PSComputerName")]
        public string? PSComputerName { get; set; }

    }
}
