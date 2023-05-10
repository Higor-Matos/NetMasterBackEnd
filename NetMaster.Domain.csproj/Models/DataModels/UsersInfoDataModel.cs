// NetMaster.Domain/Models/DataModels/UsersInfoDataModel.cs
namespace NetMaster.Domain.Models.DataModels
{
    public class LocalUserModel
    {
        public string? Name { get; set; }
    }

    public class UsersInfoDataModel : BaseInfoDataModel
    {
        public List<LocalUserModel>? Users { get; set; }
    }
}
