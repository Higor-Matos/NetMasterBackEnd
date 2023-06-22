using Microsoft.AspNetCore.Http;
using NetMaster.Domain.Models.Results;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Infrastructure.Utils;
using NetMaster.Repository.Interfaces.Uploud;
using NetMaster.Services.Interfaces.Upload;

namespace NetMaster.Repository.Implementations.Upload
{
    public class FileUploadRepository : IFileUploadRepository
    {
        private readonly IUploadFileRepository _uploadFileRepository;

        public FileUploadRepository(IUploadFileRepository uploadFileRepository)
        {
            _uploadFileRepository = uploadFileRepository ?? throw new ArgumentNullException(nameof(uploadFileRepository));
        }

        public ServiceResultModel<string> UploadFile(IFormFile file)
        {
            if (file == null)
            {
                return new ServiceResultModel<string>(
                    error: new ErrorServiceResult("File not provided.", DateTime.Now, Environment.MachineName)
                );
            }

            string destinationFolder = "Uploads";
            byte[] fileData = FileUtils.ReadFileData(file);

            RepositoryResultModel<UploadResult> resultRep = _uploadFileRepository.UploadFile(file.FileName, fileData, destinationFolder);
            return resultRep.Success && resultRep.Data != null
                ? new ServiceResultModel<string>(
                    success: new SuccessServiceResult<string>(resultRep.Data.Message!, DateTime.Now, Environment.MachineName)
                )
                : new ServiceResultModel<string>(
                    error: new ErrorServiceResult(resultRep.ErrorResult?.Message ?? "An error occurred while uploading the file.", DateTime.Now, Environment.MachineName)
                );
        }
    }
}
