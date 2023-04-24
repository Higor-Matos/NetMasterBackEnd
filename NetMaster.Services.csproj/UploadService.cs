using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Upload;

namespace NetMaster.Services
{
    public class UploadService
    {
        private readonly UploadFileRepository uploadFileRepository = new();

        public ServiceResultModel UploadFile(string fileName, byte[] fileData, string destinationFolder)
        {
            RepositoryResultModel resultRep = uploadFileRepository.UploadFile(fileName, fileData, destinationFolder);
            return RunCommand(resultRep);
        }

        private static ServiceResultModel RunCommand(RepositoryResultModel result)
        {
            if (result.SuccessResult != null)
            {
                return new ServiceResultModel(success: new SuccessServiceResult(result.SuccessResult.Result));
            }
            else
            {
                string msgError = result.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                return new ServiceResultModel(error: new ErrorServiceResult(msgError));
            }
        }
    }
}


