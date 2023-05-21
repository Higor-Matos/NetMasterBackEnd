// NetMaster.Domain.Models.Results/Results/ErrorRepositoryResult.cs

namespace NetMaster.Domain.Models.Results.Repository
{
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
