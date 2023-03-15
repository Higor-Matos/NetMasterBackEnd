using Microsoft.Extensions.Configuration;

namespace NetMaster.Repository.Local.Configuration
{
    public class ConfigurationRepository
    {
        private IConfigurationRoot Configuration { get; }

        public ConfigurationRepository()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public string GetValue(string key) => Configuration.GetSection(key).Value ?? string.Empty;
    }
}
