using Microsoft.Extensions.Configuration;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Repository.Implementations.Powershell;
using NetMaster.Repository.Interfaces.FileDistribution;
using System.Management.Automation;

namespace NetMaster.Repository.Implementations.FileDistribution
{
    public class SendFileRepository : BasePowershellRepository, ISendFileRepository
    {
        private readonly IConfiguration _configuration;

        public SendFileRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<RepositoryResultModel<string>> SendFile(RepositoryPowerShellParamModel param, string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            string driveLetter = "Z:";
            string networkPath = $"\\\\{param.Ip}\\d";
            string username = _configuration["Credentials:Username"];
            string password = _configuration["Credentials:Password"];
            string batFilePath = Path.GetTempFileName() + ".bat";

            string[] lines = {
                $"net use {driveLetter} /delete",  // Remove any existing network drive
                $"net use {driveLetter} {networkPath} /user:{username} {password}",
                $"copy \"{filePath}\" {driveLetter}\\",
                $"net use {driveLetter} /delete"  // Clean up
            };

            File.WriteAllLines(batFilePath, lines);

            string command = batFilePath;

            return await ExecCommandLocal(command, jsonOutput => jsonOutput);
        }



        public async Task<RepositoryResultModel<T>> ExecCommandLocal<T>(string command, Func<string, T> convertOutput)
        {
            using PowerShell powerShell = PowerShell.Create();
            try
            {
                _ = powerShell.AddScript(command);

                PSDataCollection<PSObject> commandResult = await Task.Factory.FromAsync<PSDataCollection<PSObject>>(
                    powerShell.BeginInvoke(),
                    powerShell.EndInvoke);

                string returnResult = string.Join(Environment.NewLine, commandResult);
                T? convertedResult = convertOutput(returnResult);

                return new RepositoryResultModel<T>(data: convertedResult, success: convertedResult != null);
            }
            catch (Exception e)
            {
                return new RepositoryResultModel<T>(error: new ErrorRepositoryResult(e));
            }
        }
    }
}