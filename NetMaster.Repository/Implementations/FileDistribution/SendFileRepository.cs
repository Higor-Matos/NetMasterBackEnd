using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Repository.Implementations.Powershell;
using NetMaster.Repository.Interfaces.FileDistribution;

namespace NetMaster.Repository.Implementations.FileDistribution
{
    public class SendFileRepository : BasePowershellRepository, ISendFileRepository
    {
        public async Task<RepositoryResultModel<string>> SendFile(RepositoryPowerShellParamModel param, string filePath)
        {
            string command = $"Copy-Item -Path {filePath} -Destination D:\\ -Force -Recurse";

            return await ExecCommand(param, command, jsonOutput => jsonOutput);
        }
    }
}
