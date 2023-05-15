using Microsoft.AspNetCore.Http;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Uploud;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.BaseCommands;

namespace NetMaster.Services
{
    public class UploadService : BaseService
    {
        private readonly UploadFileRepository _uploadFileRepository;

        public UploadService(ICommandRunner commandRunner, IResultConverter resultConverter) : base(commandRunner, resultConverter)
        {
            _uploadFileRepository = new UploadFileRepository();
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
