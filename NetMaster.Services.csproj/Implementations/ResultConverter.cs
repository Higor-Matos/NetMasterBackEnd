// NetMaster.Services/Implementations/ResultConverter.cs
using NetMaster.Domain.Models.Results;
using NetMaster.Services.Interfaces;

namespace NetMaster.Services.Implementations
{
    public class ResultConverter : IResultConverter
    {
        public RepositoryResultModel<object> Convert(RepositoryResultModel<string> result)
        {
            return result.SuccessResult != null
                ? new RepositoryResultModel<object>(data: result.SuccessResult.Result, success: true, error: result.ErrorResult)
                : new RepositoryResultModel<object>(success: false, error: result.ErrorResult);
        }
    }
}
