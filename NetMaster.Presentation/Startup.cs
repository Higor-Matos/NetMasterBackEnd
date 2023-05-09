using NetMaster.Presentation.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureAppSettings(builder);
builder.ConfigureServices();
builder.ConfigureRepositories();

WebApplication app = builder.Build();

app.ConfigureMiddlewares();

app.Run();
