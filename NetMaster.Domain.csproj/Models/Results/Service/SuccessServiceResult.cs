// NetMaster.Domain.Models.Results/SuccessServiceResult.cs

namespace NetMaster.Domain.Models.Results.Service
{
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
}

// NetMaster.Domain.Models.Results/SuccessServiceResult.Generic.cs
namespace NetMaster.Domain.Models.Results.Service
{
    public class SuccessServiceResult<T> : SuccessServiceResult
    {
        public SuccessServiceResult(T result, DateTime timestamp, string computerName) : base(timestamp, computerName)
        {
            Result = result;
        }

        public T Result { get; }
    }
}
