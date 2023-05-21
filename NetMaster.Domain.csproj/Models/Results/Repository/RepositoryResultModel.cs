// NetMaster.Domain.Models.Results/Results/RepositoryResultModel.cs

namespace NetMaster.Domain.Models.Results.Repository
{
    public class RepositoryResultModel
    {
        public string Ip { get; set; }
        public SuccessRepositoryResult? SuccessResult { get; set; } = null;
        public ErrorRepositoryResult? ErrorResult { get; set; } = null;

        protected RepositoryResultModel(SuccessRepositoryResult? success = null, ErrorRepositoryResult? error = null, string ip = "")
        {
            SuccessResult = success;
            ErrorResult = error;
            Ip = ip;
        }
    }
}


// NetMaster.Domain.Models.Results/Results/RepositoryResultModel.Generic.cs
namespace NetMaster.Domain.Models.Results.Repository
{
    public class RepositoryResultModel<T> : RepositoryResultModel
    {
        public T? Data { get; set; } // Alterado para ser anulável
        public bool Success { get; set; }
        public string Message { get; set; }

        public new SuccessRepositoryResult<T>? SuccessResult { get; set; } = null;

        public RepositoryResultModel(T? data = default, bool success = false, string message = "", ErrorRepositoryResult? error = null, string ip = "")
            : base(success ? new SuccessRepositoryResult<T>(data) : null, error, ip)
        {
            Data = data;
            Success = success;
            Message = message;
            Ip = ip;
        }

        public RepositoryResultModel(RepositoryResultModel model)
        {
            if (model.SuccessResult != null)
            {
                SuccessResult = (SuccessRepositoryResult<T>?)model.SuccessResult;
            }
            ErrorResult = model.ErrorResult;
        }
    }
}
