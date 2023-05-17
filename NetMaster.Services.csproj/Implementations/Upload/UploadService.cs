// NetMaster.Services/Implementations/Upload/UploadService.cs
using Microsoft.AspNetCore.Http;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces.Uploud;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.Upload;

namespace NetMaster.Services.Implementation.Upload
{
    public class UploadService : BaseService, IUploadService
    {
        private readonly IUploadFileRepository _uploadFileRepository;

        public UploadService(ICommandRunner commandRunner, IResultConverter resultConverter, IUploadFileRepository uploadFileRepository)
            : base(commandRunner, resultConverter)
        {
            _uploadFileRepository = uploadFileRepository;
        }

        public ServiceResultModel<object> ValidateFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return new ServiceResultModel<object>(
                    error: new ErrorServiceResult("File not provided or empty.", DateTime.Now, Environment.MachineName)
                );
            }

            return new ServiceResultModel<object>(
                success: new SuccessServiceResult<object>(null, DateTime.Now, Environment.MachineName)
            );
        }

        public ServiceResultModel<UploadResult> UploadFile(IFormFile file)
        {
            ServiceResultModel<object> validationResult = ValidateFile(file);
            if (!validationResult.IsSuccess)
            {
                return new ServiceResultModel<UploadResult>(error: validationResult.ErrorResult);
            }

            string destinationFolder = "Uploads";
            byte[] fileData = ReadFileData(file);

            RepositoryResultModel<UploadResult> resultRep = _uploadFileRepository.UploadFile(file.FileName, fileData, destinationFolder);
            if (resultRep.Success)
            {
                return new ServiceResultModel<UploadResult>(
                    success: new SuccessServiceResult<UploadResult>(resultRep.Data, DateTime.Now, Environment.MachineName)
                );
            }
            else
            {
                return new ServiceResultModel<UploadResult>(
                    error: new ErrorServiceResult(resultRep.ErrorResult.Message, DateTime.Now, Environment.MachineName)
                );
            }
        }




        private byte[] ReadFileData(IFormFile file)
        {
            using MemoryStream memoryStream = new();
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
