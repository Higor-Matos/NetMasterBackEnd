using NetMaster.Domain.Configuration;
using NetMaster.Infrastructure;
using NetMaster.Presentation.Extensions;

namespace NetMaster.Presentation.Configuration
{
    public class MongoDbContextConfiguration : AppServiceConfigurationBase
    {
        public MongoDbContextConfiguration(IServiceCollection services, WebApplicationBuilder builder) : base(services, builder)
        {
        }

        public override void ConfigureServices()
        {
            RegisterMongoDbContext();
        }

        private void RegisterMongoDbContext()
        {
            _ = _services.AddSingleton<MongoDbContext>(provider =>
            {
                IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
                MongoDbSettings mongoDbSettings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
                return new MongoDbContext(mongoDbSettings.ConnectionString, mongoDbSettings.DatabaseName);
            });
        }
    }
}
