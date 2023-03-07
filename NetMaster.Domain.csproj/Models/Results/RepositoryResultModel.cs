namespace NetMaster.Domain.Models.Results
{
    public class RepositoryResultModel
    {
        public RepositoryResultModel(
            SuccessRepositoryResult? success = null,
            ErrorRepositoryResult? error = null
        )
        {
            SuccessResult = success;
            ErrorResult = error;
        }

        public SuccessRepositoryResult? SuccessResult { get; }
        public ErrorRepositoryResult? ErrorResult { get; }
    }

    public class SuccessRepositoryResult
    {
        public SuccessRepositoryResult(string result)
        {
            Result = result;
        }

        public string Result { get; }
    }

    public class ErrorRepositoryResult
    {
        public ErrorRepositoryResult(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; }
    }
}
