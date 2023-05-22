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

        public string ErrorMessage { get; set; }
        public DateTime Timestamp { get; set; }
        public string ComputerName { get; set; }
    }
}
