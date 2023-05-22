using Microsoft.AspNetCore.Http;
using NetMaster.Common;
using NetMaster.Domain.Models.Results;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Services.Interfaces.Base;

namespace NetMaster.Services.Interfaces.Upload
{
    [AutoDI]
    public interface IFileUploadService : IBaseService
    {
        ServiceResultModel<object> ValidateFile(IFormFile file);
        ServiceResultModel<UploadResult> UploadFile(IFormFile file);
    }
}
