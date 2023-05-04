namespace NetMaster.Domain.Models.DataModels
{
    public class InstalledProgramsResponse : BaseInfoModel
    {
        public string? PSComputerName { get; set; }
        public List<InstalledProgramInfoModel>? InstalledPrograms { get; set; }
    }

    public class InstalledProgramInfoModel
    {
        public string? DisplayName { get; set; }
        public string? DisplayVersion { get; set; }
    }

}
