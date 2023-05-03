using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Upload;

namespace NetMaster.Services
{
    public class UploadService
    {
        private readonly UploadFileRepository uploadFileRepository = new();

        public ServiceResultModel<object> UploadFile(string fileName, byte[] fileData, string destinationFolder)
        {
            RepositoryResultModel<string> resultRep = uploadFileRepository.UploadFile(fileName, fileData, destinationFolder);
            return RunCommand(ConvertResult(resultRep));
        }


        private static ServiceResultModel<object> RunCommand(RepositoryResultModel<object> result)
        {
            DateTime timestamp = DateTime.UtcNow;
            string computerName = Environment.MachineName;

            if (result.SuccessResult != null)
            {
                return new ServiceResultModel<object>(success: new SuccessServiceResult<object>(result.SuccessResult.Result, timestamp, computerName));
            }
            else
            {
                string msgError = result.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                return new ServiceResultModel<object>(error: new ErrorServiceResult(msgError, timestamp, computerName));
            }
        }

        private static RepositoryResultModel<object> ConvertResult(RepositoryResultModel<string> result)
        {
            return result.SuccessResult != null
                ? new RepositoryResultModel<object>(new SuccessRepositoryResult<object>(result.SuccessResult.Result), result.ErrorResult)
                : new RepositoryResultModel<object>(null, result.ErrorResult);
        }

    }
}


