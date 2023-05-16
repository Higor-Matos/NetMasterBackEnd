//NetMaster.Presentation/Startup.cs
using NetMaster.Domain.Configuration;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;
using NetMaster.Presentation.Configuration;
using NetMaster.Repository.Interfaces.BaseCommand;
using NetMaster.Repository.Interfaces.Hardware;
using NetMaster.Repository.Interfaces.Software;
using NetMaster.Repository.Local.Hardware;
using NetMaster.Repository.Local.Software;
using NetMaster.Repository.Local.System;
using NetMaster.Services;
using NetMaster.Services.Implementations.BackgroundServices;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Implementations.Hardware;
using NetMaster.Services.Implementations.Network;
using NetMaster.Services.Implementations.Software;
using NetMaster.Services.Interfaces.BaseCommands;
using NetMaster.Services.Interfaces.Hardware;
using NetMaster.Services.Interfaces.Software;

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
builder.Services.AddScoped<ICommandRunner, CommandRunner>();
builder.Services.AddScoped<IResultConverter, ResultConverter>();
builder.Services.AddScoped<IAdobeReaderInstallerService, AdobeReaderInstallerService>();
builder.Services.AddScoped<IFirefoxInstallerService, FirefoxInstallerService>();
builder.Services.AddScoped<IVlcInstallerService, VlcInstallerService>();
builder.Services.AddScoped<IWinrarInstallerService, WinrarInstallerService>();
builder.Services.AddScoped<IGoogleChromeInstallerService, GoogleChromeInstallerService>();
builder.Services.AddScoped<IOffice365InstallerService, Office365InstallerService>();
builder.Services.AddScoped<IInstallAdobeReaderRepository, InstallAdobeReaderRepository>();
builder.Services.AddScoped<IInstallFirefoxRepository, InstallFirefoxRepository>();
builder.Services.AddScoped<IInstallVlcRepository, InstallVlcRepository>();
builder.Services.AddScoped<IInstallWinrarRepository, InstallWinrarRepository>();
builder.Services.AddScoped<IInstallGoogleChromeRepository, InstallGoogleChromeRepository>();
builder.Services.AddScoped<IInstallOffice365Repository, InstallOffice365Repository>();

builder.Services.AddScoped<Dictionary<string, ISoftwareInstallerService>>(provider => new Dictionary<string, ISoftwareInstallerService>
{
    { "AdobeReader", provider.GetRequiredService<IAdobeReaderInstallerService>() },
    { "Firefox", provider.GetRequiredService<IFirefoxInstallerService>() },
    { "Vlc", provider.GetRequiredService<IVlcInstallerService>() },
    { "Winrar", provider.GetRequiredService<IWinrarInstallerService>() },
    { "GoogleChrome", provider.GetRequiredService<IGoogleChromeInstallerService>() },
    { "Office365", provider.GetRequiredService<IOffice365InstallerService>() },
});

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
