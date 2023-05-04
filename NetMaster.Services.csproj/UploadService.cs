using Microsoft.AspNetCore.Http;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Upload;

namespace NetMaster.Services
{
    public class UploadService : BaseService
    {
        private readonly UploadFileRepository _uploadFileRepository;

        public UploadService()
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
            using (MemoryStream memoryStream = new())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
