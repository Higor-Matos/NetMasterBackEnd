using Microsoft.AspNetCore.Http;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Repository.Interfaces.Upload;

namespace NetMaster.Repository.Implementations.Upload
{
    public class FileValidationService : IFileValidationService
    {
        public ServiceResultModel<object> ValidateFile(IFormFile file)
        {
            return file == null || file.Length == 0
                ? new ServiceResultModel<object>(
                    error: new ErrorServiceResult("File not provided or empty.", DateTime.Now, Environment.MachineName)
                )
                : new ServiceResultModel<object>(
                success: new SuccessServiceResult<object>(null!, DateTime.Now, Environment.MachineName)
            );
        }
    }
}
