using NetMaster.Common;
using NetMaster.Infrastructure.Context;
using NetMaster.Repository.Interfaces.Base;
using NetMaster.Services.Interfaces.Software;
using System.Reflection;

namespace NetMaster.Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServicesInAssembly(this IServiceCollection services)
        {
            IEnumerable<Assembly> assemblies = GetAssembliesToScan();
            RegisterServices(services, assemblies);

            return services;
        }

        private static IEnumerable<Assembly> GetAssembliesToScan()
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            IEnumerable<Assembly> assemblies = entryAssembly.GetReferencedAssemblies()
                .Select(Assembly.Load)
                .Concat(new[] { entryAssembly });

            Assembly repositoryAssembly = Assembly.Load("NetMaster.Repository");
            assemblies = assemblies.Concat(new[] { repositoryAssembly });

            return assemblies;
        }

        private static void RegisterServices(IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                IEnumerable<Type> types = assembly.ExportedTypes;

                foreach (Type type in types.Where(t => t.IsClass && !t.IsAbstract))
                {
                    RegisterServiceForType(services, type);
                }
            }
        }

        private static void RegisterServiceForType(IServiceCollection services, Type type)
        {
            foreach (Type @interface in type.GetInterfaces())
            {
                var autoDiAttribute = @interface.GetCustomAttribute<AutoDIAttribute>();

                if (autoDiAttribute is not null)
                {
                    RegisterService(services, type, @interface);
                }
            }
        }


        private static void RegisterService(IServiceCollection services, Type type, Type @interface)
        {
            if (typeof(IHostedService).IsAssignableFrom(type))
            {
                // Register hosted service
                _ = services.AddSingleton(typeof(IHostedService), type);
            }
            else if (@interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IBaseMongoRepository<>))
            {
                // Register base Mongo repository
                RegisterBaseMongoRepository(services, @interface, type);
            }
            else if (@interface == typeof(ISoftwareInstallerService))
            {
                // Register software installer service dictionary
                _ = services.AddScoped(provider =>
                {
                    Dictionary<string, ISoftwareInstallerService> dictionary = new()
                    {
                        { "AdobeReader", provider.GetRequiredService<IAdobeReaderInstallerService>() },
                        { "Firefox", provider.GetRequiredService<IFirefoxInstallerService>() },
                        { "GoogleChrome", provider.GetRequiredService<IGoogleChromeInstallerService>() },
                        { "Office365", provider.GetRequiredService<IOffice365InstallerService>() },
                        { "Vlc", provider.GetRequiredService<IVlcInstallerService>() },
                        { "Winrar", provider.GetRequiredService<IWinrarInstallerService>() }
                    };
                    return dictionary;
                });
            }
            else
            {
                // Register all other services
                _ = services.AddScoped(@interface, type);
            }
        }

        private static void RegisterBaseMongoRepository(IServiceCollection services, Type @interface, Type type)
        {
            // Register the service with a factory that can provide the necessary parameters
            _ = services.AddScoped(@interface, provider =>
            {
                MongoDbContext dbContext = provider.GetRequiredService<MongoDbContext>();
                Type genericArg = @interface.GetGenericArguments().FirstOrDefault();

                if (genericArg != null)
                {
                    var instance = Activator.CreateInstance(type, dbContext, genericArg.Name);
                    if (instance is not null)
                    {
                        return instance;
                    }
                }

                throw new InvalidOperationException($"Failed to create an instance of {type.FullName}.");
            });
        }

    }
}
