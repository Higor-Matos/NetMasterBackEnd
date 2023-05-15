// NetMaster.Domain/Models/DataModels/RamInfoDataModel.cs
namespace NetMaster.Domain.Models.DataModels
{
    public class RamInfoDataModel : BaseInfoDataModel
    {
        public double FreePhysicalMemory_GB { get; set; }
        public double TotalVisibleMemorySize_GB { get; set; }
        public string? PSComputerName { get; set; }

    }
}