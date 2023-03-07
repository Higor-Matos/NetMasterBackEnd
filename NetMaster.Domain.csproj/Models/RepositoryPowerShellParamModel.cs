namespace NetMaster.Domain.Models
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
