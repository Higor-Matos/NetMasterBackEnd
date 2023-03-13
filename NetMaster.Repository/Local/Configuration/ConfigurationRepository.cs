using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
