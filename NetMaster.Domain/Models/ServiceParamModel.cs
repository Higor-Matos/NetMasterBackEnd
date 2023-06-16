namespace NetMaster.Domain.Models
{
    public class ServiceParamModel
    {
        public ServiceParamModel(string ip)
        {
            Ip = ip;
        }

        public string Ip { get; }
    }
}
