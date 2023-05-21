namespace NetMaster.Domain.Models.DataModels
{
    public class RepositoryPowerShellParamModel
    {
        public RepositoryPowerShellParamModel(string ip)
        {
            Ip = ip;
        }

        public string Ip { get; }
    }
}
