// NetMaster.Domain.Models.Results/ServiceResultModel.Generic.cs

namespace NetMaster.Domain.Models.Results.Service
{
    public class ServiceResultModel<T> where T : class
    {
        public ServiceResultModel(
            SuccessServiceResult<T>? success = null,
            ErrorServiceResult? error = null
        )
        {
            SuccessResult = success;
            ErrorResult = error;
        }

        public SuccessServiceResult<T>? SuccessResult { get; }
        public ErrorServiceResult? ErrorResult { get; }
        public bool IsSuccess => SuccessResult != null;
        public T? Success => SuccessResult?.Result;
        public string? Error => ErrorResult?.ErrorMessage;
    }
}
