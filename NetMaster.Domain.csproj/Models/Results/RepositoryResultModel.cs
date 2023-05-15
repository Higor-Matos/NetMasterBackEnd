// NetMaster.Domain.Models.Results/Results/RepositoryResultModel.cs
namespace NetMaster.Domain.Models.Results
{
    public class RepositoryResultModel
    {
        public SuccessRepositoryResult? SuccessResult { get; set; }
        public ErrorRepositoryResult? ErrorResult { get; set; }

        protected RepositoryResultModel(SuccessRepositoryResult? success = null, ErrorRepositoryResult? error = null)
        {
            SuccessResult = success;
            ErrorResult = error;
        }
    }

    public class RepositoryResultModel<T> : RepositoryResultModel
    {
        public T Data { get;  set; }
        public bool Success { get;  set; }
        public string Message { get;  set; }

        public new SuccessRepositoryResult<T>? SuccessResult
        {
            get => (SuccessRepositoryResult<T>?)base.SuccessResult;
            protected set => base.SuccessResult = value;
        }

        public RepositoryResultModel(T data = default(T), bool success = false, string message = "", ErrorRepositoryResult? error = null)
            : base(success ? new SuccessRepositoryResult<T>(data) : null, error)
        {
            Data = data;
            Success = success;
            Message = message;
        }

        public RepositoryResultModel(RepositoryResultModel model)
        {
            SuccessResult = (SuccessRepositoryResult<T>?)model.SuccessResult;
            ErrorResult = model.ErrorResult;
        }
    }

    public class SuccessRepositoryResult
    {
    }

    public class SuccessRepositoryResult<T> : SuccessRepositoryResult
    {
        public SuccessRepositoryResult(T result)
        {
            Result = result;
        }

        public T Result { get; }
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
