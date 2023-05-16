// NetMaster.Services/Implementations/Uplooud/UploadService.cs
using Microsoft.AspNetCore.Http;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces;
using NetMaster.Repository.Interfaces.Uploud;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces;
using NetMaster.Services.Interfaces.BaseCommands;
using NetMaster.Services.Interfaces.Uploud;

namespace NetMaster.Services.Implementation.Uploud
{
    public class UploadService : BaseService, IUploadService
    {
        private readonly IUploadFileRepository _uploadFileRepository;

        public UploadService(ICommandRunner commandRunner, IResultConverter resultConverter, IUploadFileRepository uploadFileRepository)
            : base(commandRunner, resultConverter)
        {
            _uploadFileRepository = uploadFileRepository;
        }

        public ServiceResultModel<object> UploadFile(IFormFile file)
        {
            string destinationFolder = "Uploads";
            byte[] fileData = ReadFileData(file);

            RepositoryResultModel<string> resultRep = _uploadFileRepository.UploadFile(file.FileName, fileData, destinationFolder);
            return RunCommand(ConvertResult(resultRep));
        }

        private byte[] ReadFileData(IFormFile file)
        {
            using MemoryStream memoryStream = new();
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
