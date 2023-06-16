// NetMaster.Services/Interfaces/Software/IUploadFileRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.Results;
using NetMaster.Domain.Models.Results.Repository;

namespace NetMaster.Repository.Interfaces.Upload
{
    [AutoDI]
    public interface IUploadFileRepository
    {
        RepositoryResultModel<UploadResult> UploadFile(string fileName, byte[] fileData, string destinationFolder);
    }
}
