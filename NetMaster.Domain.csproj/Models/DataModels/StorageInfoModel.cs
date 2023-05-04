namespace NetMaster.Domain.Models.DataModels
{
    public class StorageInfoModel
    {
        public string? DeviceID { get; set; }
        public double Size_GB { get; set; }
        public double FreeSpace_GB { get; set; }
        public string? PSComputerName { get; set; }
        public string? Timestamp { get; set; }
        public string? IpAddress { get; set; }
    }
}
