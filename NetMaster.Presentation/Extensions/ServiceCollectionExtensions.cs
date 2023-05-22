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
            assemblies ??= Enumerable.Empty<Assembly>();

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
                AutoDIAttribute? autoDiAttribute = @interface.GetCustomAttribute<AutoDIAttribute>();

                if (autoDiAttribute != null)
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
                RegisterHostedService(services, type);
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

            Console.WriteLine($"Registered {@interface.FullName} with {type.FullName}");
        }

        private static void RegisterHostedService(IServiceCollection services, Type serviceType)
        {
            // Use a specific method to register hosted services
            MethodInfo genericMethod = typeof(ServiceCollectionHostedServiceExtensions)
                .GetMethods()
                .Where(m => m.Name == nameof(ServiceCollectionHostedServiceExtensions.AddHostedService) && m.IsGenericMethod)
                .First();

            MethodInfo constructedMethod = genericMethod.MakeGenericMethod(serviceType);
            _ = constructedMethod.Invoke(null, new object[] { services });
        }

        private static void RegisterBaseMongoRepository(IServiceCollection services, Type @interface, Type type)
        {
            // Register the service with a factory that can provide the necessary parameters
            _ = services.AddScoped(@interface, provider =>
            {
                MongoDbContext dbContext = provider.GetRequiredService<MongoDbContext>();
                Type genericArg = @interface.GetGenericArguments()[0];

                return Activator.CreateInstance(type, dbContext, genericArg.Name)!;
            });
        }
    }
}
