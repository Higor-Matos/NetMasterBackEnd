namespace NetMaster.Domain.Models.Results.Repository
{
    public class RepositoryResultModel<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Ip { get; set; }

        public SuccessRepositoryResult<T>? SuccessResult { get; }
        public ErrorRepositoryResult? ErrorResult { get; set; }

        public RepositoryResultModel(T? data = default, bool success = false, string message = "", ErrorRepositoryResult? error = null, string ip = "")
        {
            Data = data;
            Success = success;
            Message = message;
            Ip = ip;
            ErrorResult = error;

            if (success)
            {
                SuccessResult = new SuccessRepositoryResult<T>(data!);
            }
        }

        public RepositoryResultModel(RepositoryResultModel<T> model)
        {
            if (model.SuccessResult != null)
            {
                SuccessResult = new SuccessRepositoryResult<T>(model.SuccessResult.Result);
            }
            Data = model.Data;
            Success = model.Success;
            Message = model.Message;
            Ip = model.Ip;
            ErrorResult = model.ErrorResult;
        }
    }
}
