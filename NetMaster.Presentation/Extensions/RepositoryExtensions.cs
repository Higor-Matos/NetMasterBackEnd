// NetMaster.Presentation/Extensions/RepositoryExtensions.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Repository;
using NetMaster.Repository.Local.Hardware;
using NetMaster.Repository.Local.System;

namespace NetMaster.Presentation.Extensions
{
    public static class RepositoryExtensions
    {
        public static void ConfigureRepositories(this WebApplicationBuilder builder)
        {
            IServiceCollection services = builder.Services;
            _ = services.AddScoped<IBaseRepository<RamInfoDataModel>, RamRepository>();
            _ = services.AddScoped<IBaseRepository<StorageInfoDataModel>, StorageRepository>();
            _ = services.AddScoped<IBaseRepository<ChocolateyInfoDataModel>, ChocolateyRepository>();
            _ = services.AddScoped<IBaseRepository<InstalledProgramsResponseModel>, InstalledProgramsRepository>();
            _ = services.AddScoped<IBaseRepository<UsersInfoDataModel>, UsersRepository>();
            _ = services.AddScoped<IBaseRepository<OSVersionInfoDataModel>, OsVersionRepository>();
            _ = services.AddScoped<ShutdownPcRepository>();
            _ = services.AddScoped<RestartPcRepository>();
            _ = services.AddScoped<LocalRamRepository>(); 
            _ = services.AddScoped<LocalStorageRepository>();
            _ = services.AddScoped<LocalChocolateyRepository>();
            _ = services.AddScoped<LocalUsersRepository>();
            _ = services.AddScoped<LocalOsVersionRepository>();
            _ = services.AddScoped<LocalInstalledProgramsRepository>();
        }
    }
}
