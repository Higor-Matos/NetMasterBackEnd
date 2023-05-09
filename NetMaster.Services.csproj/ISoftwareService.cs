using NetMaster.Domain.Models.Results;

namespace NetMaster.Services
{
    public interface ISoftwareService
    {
        Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip, string software);
    }
}
