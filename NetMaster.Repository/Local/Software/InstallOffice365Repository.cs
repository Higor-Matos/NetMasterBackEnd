﻿using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell;

namespace NetMaster.Repository.Local.Software
{
    public class InstallOffice365Repository : BasePowershellRepository
    {
        private static readonly string command = "choco install office365business -y --force";

        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await ExecCommand(param, command, jsonOutput => jsonOutput);
        }
    }
}