using NetMaster.Presentation.Configuration;
using NetMaster.Presentation.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
new AppServiceConfiguration(builder.Services, builder).ConfigureServices();
List<AppServiceConfigurationBase> configurations = new()
{
    new MongoDbContextConfiguration(builder.Services, builder),
};

foreach (AppServiceConfigurationBase config in configurations)
{
    config.ConfigureServices();
}

WebApplication app = builder.Build();

app.ConfigureMiddlewares();

app.Run();

