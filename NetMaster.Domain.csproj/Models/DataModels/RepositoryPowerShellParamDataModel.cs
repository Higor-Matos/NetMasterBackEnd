// NetMaster.Domain/Models/DataModels/RepositoryPowerShellParamDataModel.cs
namespace NetMaster.Domain.Models.DataModels
{
    public class RepositoryPowerShellParamDataModel
    {
        public string Ip { get; }

        public RepositoryPowerShellParamDataModel(string ip)
        {
            Ip = ip;
        }
    }
}
