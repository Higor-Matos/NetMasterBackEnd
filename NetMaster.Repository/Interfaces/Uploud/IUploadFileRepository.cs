// NetMaster.Services/Interfaces/Software/IUploadFileRepository.cs
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.Uploud
{
    public interface IUploadFileRepository
    {
        RepositoryResultModel<string> UploadFile(string fileName, byte[] fileData, string destinationFolder);
    }
}
