namespace NetMaster.Domain.Models.DataModels
{
    public class LocalUserModel
    {
        public string? Name { get; set; }
    }

    public class LocalUsersInfoModel : BaseInfoModel
    {
        public List<LocalUserModel>? Users { get; set; }
        public string? PSComputerName { get; set; }

    }
}