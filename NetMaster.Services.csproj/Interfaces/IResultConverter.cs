// NetMaster.Services/Interfaces/IResultConverter.cs
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces
{
    public interface IResultConverter
    {
        RepositoryResultModel<object> Convert(RepositoryResultModel<string> result);
    }
}
