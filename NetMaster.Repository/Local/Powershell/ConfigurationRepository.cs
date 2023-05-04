using Microsoft.Extensions.Configuration;

namespace NetMaster.Repository.Local.Powershell
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

        public string GetValue(string key)
        {
            return Configuration.GetSection(key).Value ?? string.Empty;
        }
    }
}
