// NetMaster.Domain/Models/DataModels/InstalledProgramInfoDataModel.cs
namespace NetMaster.Domain.Models.DataModels
{
    public class InstalledProgramsResponseModel : BaseInfoDataModel
    {
        public List<InstalledProgramInfoDataModel>? Programs { get; set; }
    }

    public class InstalledProgramInfoDataModel
    {
        public string? DisplayName { get; set; }
        public string? DisplayVersion { get; set; }
    }
}