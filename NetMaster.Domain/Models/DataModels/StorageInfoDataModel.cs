namespace NetMaster.Domain.Models.DataModels
{
    public class DiskInfoDataModel
    {
        public string? DeviceID { get; set; }
        public double Size_GB { get; set; }
        public double FreeSpace_GB { get; set; }
    }

    public class StorageInfoDataModel : BaseInfoDataModel
    {
        public List<DiskInfoDataModel>? Disks { get; set; }
    }
}