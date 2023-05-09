using Microsoft.AspNetCore.Localization;
using NetMaster.Domain.Configuration;
using NetMaster.Infrastructure;
using NetMaster.Presentation.Configuration;
using NetMaster.Repository.Local.System;
using NetMaster.Services;
using System.Globalization;

namespace NetMaster.Presentation.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureAppSettings(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
            services.Configure<StreamingServerConfigPresentation>(builder.Configuration.GetSection("StreamingServer"));
        }

        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            IServiceCollection services = builder.Services;
            RegisterMongoDbContext(services, builder);
            RegisterServices(services);
            RegisterHostedServices(services);
            ConfigureSwagger(services);
            ConfigureCors(services);
            services.AddControllers();
            AddLocalization(services);
        }

        private static void RegisterMongoDbContext(IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddSingleton<MongoDbContext>(provider =>
            {
                IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
                MongoDbSettings mongoDbSettings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
                return new MongoDbContext(mongoDbSettings.ConnectionString, mongoDbSettings.DatabaseName);
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<HardwareService>();
            services.AddScoped<SoftwareService>();
            services.AddScoped<SystemService>();
            services.AddScoped<UploadService>();
            services.AddSingleton<NetworkService>();
            services.AddScoped<ComputerInfoCollectorService>();
            services.AddScoped<SystemCommandService>();
            services.AddScoped<ShutdownPcRepository>();
            services.AddScoped<RestartPcRepository>();

        }


        private static void RegisterHostedServices(IServiceCollection services)
        {
            services.AddSingleton<IHostedService, ComputerInfoBackgroundService>();
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddSwaggerDocumentation();
        }

        private static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });
        }

        private static void AddLocalization(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
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
