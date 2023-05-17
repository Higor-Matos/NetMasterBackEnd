using NetMaster.Common;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using System;
using System.Threading.Tasks;

namespace NetMaster.Services.Interfaces.System
{
    [AutoDI]
    public interface ISystemCommandService
    {
        Task<ServiceResultModel<string>> ShutdownPcCommand(string ip);
        Task<ServiceResultModel<string>> RestartPcCommand(string ip);
    }
}
