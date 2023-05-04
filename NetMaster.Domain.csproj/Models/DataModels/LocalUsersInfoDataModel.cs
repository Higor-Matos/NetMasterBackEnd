namespace NetMaster.Domain.Models.DataModels
{
    public class LocalUserModel
    {
        public string? Name { get; set; }
    }

    public class LocalUsersInfoDataModel : BaseInfoDataModel
    {
        public List<LocalUserModel>? Users { get; set; }
        public string? PSComputerName { get; set; }

    }
}