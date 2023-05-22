namespace NetMaster.Domain.Models.DataModels
{
    public class StorageInfoDataModel : BaseInfoDataModel
    {
        public string? DeviceID { get; set; }
        public double Size_GB { get; set; }
        public double FreeSpace_GB { get; set; }
    }
}
