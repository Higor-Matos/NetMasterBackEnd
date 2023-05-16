// NetMaster.Services/Interfaces/BaseCommands/IResultConverter.cs
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.BaseCommands
{
    public interface IResultConverter
    {
        RepositoryResultModel<object> Convert(RepositoryResultModel<string> result);
    }
}
