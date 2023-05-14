// NetMaster.Domain/Models/Results/RepositoryResultModel.cs
namespace NetMaster.Domain.Models.Results
{
    public class RepositoryResultModel
    {
        public SuccessRepositoryResult? SuccessResult { get; protected set; }
        public ErrorRepositoryResult? ErrorResult { get; protected set; }

        protected RepositoryResultModel(SuccessRepositoryResult? success = null, ErrorRepositoryResult? error = null)
        {
            SuccessResult = success;
            ErrorResult = error;
        }
    }

    public class RepositoryResultModel<T> : RepositoryResultModel
    {
        public new SuccessRepositoryResult<T>? SuccessResult
        {
            get => (SuccessRepositoryResult<T>?)base.SuccessResult;
            protected set => base.SuccessResult = value;
        }

        public RepositoryResultModel(SuccessRepositoryResult<T>? success = null, ErrorRepositoryResult? error = null)
            : base(success, error)
        {
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
