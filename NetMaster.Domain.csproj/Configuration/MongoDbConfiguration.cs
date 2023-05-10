///NetMaster.Domain/Models/Configuration/MongoDbSettings.cs
namespace NetMaster.Domain.Configuration
{
    public class MongoDbConfiguration
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
    }
}
