using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Repository.Implementations.Powershell;
using NetMaster.Repository.Interfaces.Software;

namespace NetMaster.Repository.Implementations.Software
{
    public class Office365InstallationRepository : BasePowershellRepository, IOffice365InstallationRepository
    {
        private static readonly string command = "choco install office365business -y --force";

        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await ExecCommand(param, command, jsonOutput => jsonOutput);
        }
    }
}