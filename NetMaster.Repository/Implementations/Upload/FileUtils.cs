using Microsoft.AspNetCore.Http;

namespace NetMaster.Repository.Implementations.Upload
{
    public static class FileUtils
    {
        public static byte[] ReadFileData(IFormFile file)
        {
            using MemoryStream memoryStream = new();
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        public static void WriteFileData(string filePath, byte[] fileData)
        {
            File.WriteAllBytes(filePath, fileData);
        }
    }

}
