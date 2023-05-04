namespace NetMaster.Domain.Models.DataModels
{
    public class LocalUser
    {
        public string? Name { get; set; }
    }

    public class LocalUsersInfoModel : BaseInfoModel
    {
        public List<LocalUser>? Users { get; set; }
        public string? PSComputerName { get; set; }

    }
}