// NetMaster.Domain.Models.Results/Results/SuccessRepositoryResult.Generic.cs
namespace NetMaster.Domain.Models.Results.Repository
{
    public class SuccessRepositoryResult<T>
    {
        public SuccessRepositoryResult(T result)
        {
            Result = result;
        }

        public T Result { get; }
    }
}
