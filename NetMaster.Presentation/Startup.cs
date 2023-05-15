//NetMaster.Presentation/Startup.cs
using NetMaster.Domain.Configuration;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;
using NetMaster.Presentation.Configuration;
using NetMaster.Repository.Interfaces;
using NetMaster.Repository.Local.Hardware;
using NetMaster.Repository.Local.System;
using NetMaster.Services;
using NetMaster.Services.Implementations.Hardware;
using NetMaster.Services.Interfaces;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.Configure<StreamingServerConfigPresentation>(builder.Configuration.GetSection("StreamingServer"));

builder.Services.AddSingleton<MongoDbContext>(provider =>
{
    IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
    MongoDbSettings mongoDbSettings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
    return new MongoDbContext(mongoDbSettings.ConnectionString, mongoDbSettings.DatabaseName);
});

builder.Services.AddControllers();
builder.Services.AddScoped<ILocalRamRepository, LocalRamRepository>();
builder.Services.AddScoped<ILocalStorageRepository, LocalStorageRepository>();
builder.Services.AddScoped<LocalChocolateyRepository>();
builder.Services.AddScoped<LocalInstalledProgramsRepository>();
builder.Services.AddScoped<LocalOsVersionRepository>();
builder.Services.AddScoped<LocalUsersRepository>();
builder.Services.AddScoped<HardwareService>();
builder.Services.AddScoped<IRamInfoService, RamInfoService>();
builder.Services.AddScoped<IStorageInfoService, StorageInfoService>();

builder.Services.AddScoped<IRamRepository, RamRepository>();
builder.Services.AddScoped<IStorageRepository, StorageRepository>();
builder.Services.AddScoped<IHardwareService, HardwareService>();
builder.Services.AddScoped<SoftwareService>();
builder.Services.AddScoped<SystemService>();
builder.Services.AddScoped<UploadService>();
builder.Services.AddSingleton<NetworkService>();
builder.Services.AddScoped<IBaseRepository<RamInfoDataModel>, RamRepository>();
builder.Services.AddScoped<IBaseRepository<StorageInfoDataModel>, StorageRepository>();
builder.Services.AddScoped<IBaseRepository<ChocolateyInfoDataModel>, ChocolateyRepository>();
builder.Services.AddScoped<IBaseRepository<InstalledProgramsResponseModel>, InstalledProgramsRepository>();
builder.Services.AddScoped<IBaseRepository<UsersInfoDataModel>, UsersRepository>();
builder.Services.AddScoped<IBaseRepository<OSVersionInfoDataModel>, OsVersionRepository>();
builder.Services.AddSingleton<IHostedService, ComputerInfoBackgroundService>();

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocumentation();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            _ = builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

WebApplication app = builder.Build();

app.UseCors("AllowAllOrigins");

app.UseRouting();

app.UseAuthorization();

app.UseSwaggerDocumentation();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});


TimeZoneInfo brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
DateTime brasiliaTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brasiliaTimeZone);


app.Run();
