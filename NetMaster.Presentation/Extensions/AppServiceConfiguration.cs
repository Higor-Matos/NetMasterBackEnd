using Microsoft.AspNetCore.Localization;
using NetMaster.Domain.Configuration;
using NetMaster.Presentation.Configuration;
using NetMaster.Repository.Local.Hardware;
using NetMaster.Repository.Local.System;
using NetMaster.Services;
using System.Globalization;

namespace NetMaster.Presentation.Extensions
{
    public class AppServiceConfiguration
    {
        private readonly IServiceCollection _services;
        private readonly WebApplicationBuilder _builder;

        public AppServiceConfiguration(IServiceCollection services, WebApplicationBuilder builder)
        {
            _services = services;
            _builder = builder;
        }

        public void ConfigureAppSettings()
        {
            _ = _services.Configure<MongoDbConfiguration>(_builder.Configuration.GetSection("MongoDbSettings"));
            _ = _services.Configure<StreamingServerConfigPresentation>(_builder.Configuration.GetSection("StreamingServer"));
        }

        public void ConfigureServices()
        {
            ConfigureAuthorization();
            _builder.ConfigureRepositories();
            RegisterRepositories();
            RegisterServices();
            RegisterHostedServices();
            ConfigureSwagger();
            ConfigureCors();
            _ = _services.AddControllers();
            AddLocalization();
        }


        private void RegisterServices()
        {
            _ = _services.AddScoped<HardwareService>();
            _ = _services.AddScoped<SoftwareService>();
            _ = _services.AddScoped<SystemService>();
            _ = _services.AddScoped<UploadService>();
            _ = _services.AddSingleton<NetworkService>();
            _ = _services.AddScoped<ComputerInfoCollectorService>();
            _ = _services.AddScoped<SystemCommandService>();
        }

        private void ConfigureAuthorization()
        {
            _ = _services.AddAuthorization();
        }

        private void RegisterRepositories()
        {
            _ = _services.AddScoped<RamRepository>();
            _ = _services.AddScoped<ChocolateyRepository>();
        }


        private void RegisterHostedServices()
        {
            _ = _services.AddSingleton<IHostedService, ComputerInfoBackgroundService>();
        }

        private void ConfigureSwagger()
        {
            _ = _services.AddSwaggerGen();
            _services.AddSwaggerDocumentation();
        }

        private void ConfigureCors()
        {
            _ = _services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        _ = builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });
        }

        private void AddLocalization()
        {
            _ = _services.AddLocalization(options => options.ResourcesPath = "Resources");

            _ = _services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new()
                {
                    new CultureInfo("pt-BR"),
                    new CultureInfo("en-US"),
                };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }
    }
}
