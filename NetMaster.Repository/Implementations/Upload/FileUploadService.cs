// NetMaster.Services/Implementations/Upload/FileUploadService.cs
using Microsoft.AspNetCore.Http;
using NetMaster.Domain.Models.Results;
using NetMaster.Services.Interfaces.Upload;
using NetMaster.Infrastructure.Utils;
using System;
using NetMaster.Repository.Interfaces.Uploud;

namespace NetMaster.Services.Implementations.Upload
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IUploadFileRepository _uploadFileRepository;

        public FileUploadService(IUploadFileRepository uploadFileRepository)
        {
            _uploadFileRepository = uploadFileRepository;
        }

        public ServiceResultModel<string> UploadFile(IFormFile file)
        {
            string destinationFolder = "Uploads";
            byte[] fileData = FileUtils.ReadFileData(file);

            RepositoryResultModel<UploadResult> resultRep = _uploadFileRepository.UploadFile(file.FileName, fileData, destinationFolder);
            if (resultRep.Success)
            {
                return new ServiceResultModel<string>(
                    success: new SuccessServiceResult<string>(resultRep.Data.Message, DateTime.Now, Environment.MachineName)
                );
            }
            else
            {
                return new ServiceResultModel<string>(
                    error: new ErrorServiceResult(resultRep.ErrorResult.Message, DateTime.Now, Environment.MachineName) // Aqui estava resultRep.Error.Message, trocamos para resultRep.ErrorResult.Message
                );
            }
        }

    }
}