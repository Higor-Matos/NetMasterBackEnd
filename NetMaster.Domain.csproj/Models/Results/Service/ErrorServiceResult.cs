// NetMaster.Domain.Models.Results/ErrorServiceResult.cs

namespace NetMaster.Domain.Models.Results.Service
{
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
