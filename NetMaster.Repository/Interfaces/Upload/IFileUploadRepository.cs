// NetMaster.Services.Interfaces.Upload/IFileUploadService.cs
using Microsoft.AspNetCore.Http;
using NetMaster.Common;
using NetMaster.Domain.Models.Results.Service;

namespace NetMaster.Repository.Interfaces.Upload
{
    [AutoDI]
    public interface IFileUploadRepository
    {
        ServiceResultModel<string> UploadFile(IFormFile file);
    }
}