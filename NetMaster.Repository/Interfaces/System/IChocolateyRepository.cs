// NetMaster.Repository/Interfaces/Hardware/IChocolateyRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface IChocolateyRepository : ISystemRepository<ChocolateyInfoDataModel>
    {
    }
}