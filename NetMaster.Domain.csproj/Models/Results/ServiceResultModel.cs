// NetMaster.Domain/Models/Results/ServiceResultModel.cs
namespace NetMaster.Domain.Models.Results
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

        public static ServiceResultModel<T> Fail(string errorMessage)
        {
            DateTime timestamp = DateTime.UtcNow;
            string computerName = Environment.MachineName;
            return new ServiceResultModel<T>(error: new ErrorServiceResult(errorMessage, timestamp, computerName));
        }

        public SuccessServiceResult<T>? SuccessResult { get; }
        public ErrorServiceResult? ErrorResult { get; }
        public bool IsSuccess => SuccessResult != null;
        public T? Success => SuccessResult?.Result;
        public string? Error => ErrorResult?.ErrorMessage;
    }

    public class SuccessServiceResult
    {
        public DateTime Timestamp { get; }
        public string ComputerName { get; }

        protected SuccessServiceResult(DateTime timestamp, string computerName)
        {
            Timestamp = timestamp;
            ComputerName = computerName;
        }
    }

    public class SuccessServiceResult<T> : SuccessServiceResult
    {
        public SuccessServiceResult(T result, DateTime timestamp, string computerName) : base(timestamp, computerName)
        {
            Result = result;
        }

        public T Result { get; }
    }

    public class ErrorServiceResult
    {
        public ErrorServiceResult(string errorMessage, DateTime timestamp, string computerName)
        {
            ErrorMessage = errorMessage;
            Timestamp = timestamp;
            ComputerName = computerName;
        }

        public string ErrorMessage { get; }
        public DateTime Timestamp { get; }
        public string ComputerName { get; }
    }
}
