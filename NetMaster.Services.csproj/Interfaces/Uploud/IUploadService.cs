// NetMaster.Services/Interfaces/Uploud/IUploadService.cs
using Microsoft.AspNetCore.Http;
using NetMaster.Common;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.Uploud
{
    [AutoDI]
    public interface IUploadService
    {
        ServiceResultModel<object> UploadFile(IFormFile file);
    }
}
