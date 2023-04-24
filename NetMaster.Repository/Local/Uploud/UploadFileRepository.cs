using NetMaster.Domain.Models.Results;
using System.IO;

namespace NetMaster.Repository.Local.Upload
{
    public class UploadFileRepository
    {
        public RepositoryResultModel UploadFile(string fileName, byte[] fileData, string destinationFolder)
        {
            try
            {
                var filePath = Path.Combine(destinationFolder, fileName);
                File.WriteAllBytes(filePath, fileData);

                return new RepositoryResultModel(success: new SuccessRepositoryResult("File uploaded successfully."));
            }
            catch (Exception e)
            {
                return new RepositoryResultModel(error: new ErrorRepositoryResult(e));
            }
        }
    }
}
