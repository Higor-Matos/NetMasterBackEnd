// NetMaster.Domain.Models.Results/Results/SuccessRepositoryResult.cs

namespace NetMaster.Domain.Models.Results.Repository
{
    public class SuccessRepositoryResult
    {
    }
}

// NetMaster.Domain.Models.Results/Results/SuccessRepositoryResult.Generic.cs
namespace NetMaster.Domain.Models.Results.Repository
{
    public class SuccessRepositoryResult<T> : SuccessRepositoryResult
    {
        public SuccessRepositoryResult(T result)
        {
            Result = result;
        }

        public T Result { get; }
    }
}
