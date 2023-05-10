// NetMaster.Domain/Models/DataModels/RamInfoDataModel.cs
namespace NetMaster.Domain.Models.DataModels
{
    public class RamInfoDataModel : BaseInfoDataModel
    {
        public double FreePhysicalMemoryGB { get; set; }
        public double TotalVisibleMemorySizeGB { get; set; }
    }
}