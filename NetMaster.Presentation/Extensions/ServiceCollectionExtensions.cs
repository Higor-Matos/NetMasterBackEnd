using NetMaster.Common;
using NetMaster.Infrastructure.Context;
using NetMaster.Repository.Interfaces.Base;
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
                    foreach (Type @interface in type.GetInterfaces())
                    {
                        AutoDIAttribute autoDiAttribute = @interface.GetCustomAttribute<AutoDIAttribute>();

                        if (autoDiAttribute != null)
                        {
                            RegisterService(services, type, @interface);
                        }
                    }
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
            constructedMethod.Invoke(null, new object[] { services });
        }


        private static void RegisterBaseMongoRepository(IServiceCollection services, Type @interface, Type type)
        {
            // Register the service with a factory that can provide the necessary parameters
            _ = services.AddScoped(@interface, provider =>
            {
                MongoDbContext dbContext = provider.GetRequiredService<MongoDbContext>();
                Type genericArg = @interface.GetGenericArguments()[0];

                return Activator.CreateInstance(type, dbContext, genericArg.Name);
            });
        }
    }
}
