namespace NetMaster.Domain.Models.DataModels
{
    public class RamInfoModel : BaseInfoModel
    {
        public double FreePhysicalMemory_GB { get; set; }
        public double TotalVisibleMemorySize_GB { get; set; }
        public string? PSComputerName { get; set; }

    }
}
