namespace NetMaster.Domain.Models.DataModels
{
    public class InstalledProgramInfoDataModel
    {
        public string? DisplayName { get; set; }
        public string? DisplayVersion { get; set; }
    }

    public class InstalledProgramsResponseModel : BaseInfoDataModel
    {
        public List<InstalledProgramInfoDataModel> Programs { get; set; }
    }
}
