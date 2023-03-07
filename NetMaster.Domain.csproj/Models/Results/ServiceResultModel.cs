namespace NetMaster.Domain.Models.Results
{
    public class ServiceResultModel
    {
        public ServiceResultModel(
            SuccessServiceResult? success = null,
            ErrorServiceResult? error = null
        )
        {
            SuccessResult = success;
            ErrorResult = error;
        }

        public SuccessServiceResult? SuccessResult { get; }
        public ErrorServiceResult? ErrorResult { get; }
    }

    public class SuccessServiceResult
    {
        public SuccessServiceResult(object result)
        {
            Result = result;
        }

        public object Result { get; }
    }

    public class ErrorServiceResult
    {
        public ErrorServiceResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}
