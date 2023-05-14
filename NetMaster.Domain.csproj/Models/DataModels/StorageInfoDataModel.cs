// NetMaster.Domain/Models/DataModels/StorageInfoDataModel.cs
namespace NetMaster.Domain.Models.DataModels
{
    public class StorageInfoDataModel : BaseInfoDataModel
    {
        public string? DeviceID { get; set; }
        public double SizeGB { get; set; }
        public double FreeSpaceGB { get; set; }
    }
}