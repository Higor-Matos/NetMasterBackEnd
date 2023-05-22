// NetMaster.Domain.Models.Results/SuccessServiceResult.cs
namespace NetMaster.Domain.Models.Results.Service
{
    public class SuccessServiceResult<T>
    {
        public T Result { get; }
        public DateTime Timestamp { get; }
        public string ComputerName { get; }

        public SuccessServiceResult(T result, DateTime timestamp, string computerName)
        {
            Result = result;
            Timestamp = timestamp;
            ComputerName = computerName;
        }
    }
}
