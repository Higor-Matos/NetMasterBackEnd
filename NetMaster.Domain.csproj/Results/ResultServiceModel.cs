namespace NetMaster.Domain.Results
{
    public class ResultServiceModel
    {
        public ResultServiceModel(
            SuccessResult? success = null,
            ErrorResult? error = null
        )
        {
            SuccessResult = success;
            ErrorResult = error;
        }

        public SuccessResult? SuccessResult { get; }
        public ErrorResult? ErrorResult { get; }
    }

    public class SuccessResult
    {
        public SuccessResult(object result)
        {
            Result = result;
        }

        public object Result { get; }
    }

    public class ErrorResult
    {
        public ErrorResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}
