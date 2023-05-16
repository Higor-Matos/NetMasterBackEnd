// NetMaster.Domain.Models.Results/Results/RepositoryResultModel.cs
namespace NetMaster.Domain.Models.Results
{
    public class RepositoryResultModel
    {
        public string Ip { get; set; }
        public SuccessRepositoryResult? SuccessResult { get; set; }
        public ErrorRepositoryResult? ErrorResult { get; set; }

        protected RepositoryResultModel(SuccessRepositoryResult? success = null, ErrorRepositoryResult? error = null, string ip = "")
        {
            SuccessResult = success;
            ErrorResult = error;
            Ip = ip;
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

        public RepositoryResultModel(T data = default(T), bool success = false, string message = "", ErrorRepositoryResult? error = null, string ip = "")
            : base(success ? new SuccessRepositoryResult<T>(data) : null, error, ip)  // Adicionado parâmetro ip
        {
            Data = data;
            Success = success;
            Message = message;
            Ip = ip;
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
        public ErrorRepositoryResult(Exception exception, string message = "")
        {
            Exception = exception;
            Message = message; 
        }

        public Exception Exception { get; }
        public string Message { get; set; } 
    }
}
