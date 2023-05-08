using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Uploud
{
    public class UploadFileRepository
    {
        public RepositoryResultModel<string> UploadFile(string fileName, byte[] fileData, string destinationFolder)
        {
            try
            {
                string filePath = Path.Combine(destinationFolder, fileName);
                WriteFileData(filePath, fileData);

                return new RepositoryResultModel<string>(success: new SuccessRepositoryResult<string>("File uploaded successfully."));

            }
            catch (Exception e)
            {
                return new RepositoryResultModel<string>(error: new ErrorRepositoryResult(e));
            }
        }

        private void WriteFileData(string filePath, byte[] fileData)
        {
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
