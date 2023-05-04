namespace NetMaster.Domain.Models.DataModels
{
    public class InstalledProgramsResponseModel : BaseInfoModel
    {
        public string? PSComputerName { get; set; }
        public List<InstalledProgramInfoModel>? Programs { get; set; }
    }

    public class InstalledProgramInfoModel
    {
        public string? DisplayName { get; set; }
        public string? DisplayVersion { get; set; }
    }
}