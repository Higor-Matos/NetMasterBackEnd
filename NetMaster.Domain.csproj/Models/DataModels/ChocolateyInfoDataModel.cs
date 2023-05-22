using MongoDB.Bson.Serialization.Attributes;

namespace NetMaster.Domain.Models.DataModels
{
    public class ChocolateyInfoDataModel : BaseInfoDataModel
    {
        public string? ChocolateyVersion { get; set; }

        public string? PSComputerName { get; set; }
    }
}
