// NetMaster.Repository/Interfaces/ILocalInstalledProgramsRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface ILocalInstalledProgramsRepository : ILocalSystemRepository<InstalledProgramsResponseModel>
    {
        Task<RepositoryResultModel<InstalledProgramsResponseModel>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}