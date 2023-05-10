// NetMaster.Domain/Models/DataModels/OSVersionInfoDataModel.cs
namespace NetMaster.Domain.Models.DataModels
{
    public class OSVersionInfoDataModel : BaseInfoDataModel
    {
        public string? Caption { get; set; }
        public string? Version { get; set; }
    }
}