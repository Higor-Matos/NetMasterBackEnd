// NetMaster.Services/Interfaces/BaseCommands/IResultConverter.cs
using NetMaster.Common;
using NetMaster.Domain.Models.Results.Repository;

namespace NetMaster.Services.Interfaces.Base
{
    [AutoDI]
    public interface IResultConverter
    {
        RepositoryResultModel<object> Convert(RepositoryResultModel<string> result);
    }
}
