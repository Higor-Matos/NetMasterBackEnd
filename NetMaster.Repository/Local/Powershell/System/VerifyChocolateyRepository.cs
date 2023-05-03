using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

public class VerifyChocolateyRepository : BasePowershellRepository
{
    public async Task<RepositoryResultModel<ChocolateyInfoModel>> ExecCommand(RepositoryPowerShellParamModel param)
    {
        string command = "choco -v; (Get-WmiObject -Class Win32_ComputerSystem).Name";

        ChocolateyInfoModel convertOutput(string output)
        {
            string[] lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            return new ChocolateyInfoModel
            {
                ChocolateyVersion = lines[0].Trim(),
                IpAddress = param.Ip,
                PSComputerName = lines.Length > 1 ? lines[1].Trim() : string.Empty,
                Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
            };
        }

        return await ExecCommand(param, command, convertOutput);
    }
}
