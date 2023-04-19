using Microsoft.Management.Infrastructure;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;


namespace NetMaster.Repository.Local.Powershell.Hardware
{
    public class GetStorageRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "Get-CimInstance -ClassName Win32_LogicalDisk | Select-Object -Property DeviceID,@{Name='Size=(GB)'; Expression={[int]($_.Size / 1GB)}},@{Name='FreeSpace=(GB)'; Expression={[int]($_.FreeSpace / 1GB)}}";
            string parameters = "";
            return await base.ExecCommand(param, command, parameters);
        }
    }
}
