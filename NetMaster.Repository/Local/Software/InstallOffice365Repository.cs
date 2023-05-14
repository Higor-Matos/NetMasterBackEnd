using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell;

namespace NetMaster.Repository.Local.Software
{
    public class InstallOffice365Repository : BasePowershellRepository, IRepository
    {
        private static readonly string command = "choco install office365business -y --force";

        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamDataModel param)
        {
            return await ExecCommand(param, command, jsonOutput => jsonOutput);
        }
    }
}