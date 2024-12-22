using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Matt.SharedKernel.DependencyInjections;

public static class ServiceCollectionsExtensions
{
    #region Extensions

    public static IServiceCollection AddServiced(this IServiceCollection services, params Assembly[] assemblies)
    {
        var compatibleAssemblies = FilterAssemblies(assemblies);

        // We don't have domain assembly reference, so that we can't handle DI for domain services
        var servicesToRegister = compatibleAssemblies
            .SelectMany(x => x.GetTypes())
            .Where(t => typeof(IServiced).IsAssignableFrom(t) && !t.IsAbstract)
            .ToList();

        foreach (var serviceToRegister in servicesToRegister)
        {
            var (serviceType, implementationType) = GetTypes(serviceToRegister);

            var lifetime = GetLifetime(serviceToRegister);

            RegisterWithTypes(services, serviceType, implementationType, lifetime);
        }

        return services;
    }

    #endregion

    #region Registration

    private static void RegisterWithTypes(IServiceCollection services, Type serviceType, Type implementationType,
        ServiceLifetime lifetime)
    {
        var descriptor = new ServiceDescriptor(serviceType, implementationType, lifetime);

        services.Add(descriptor);
    }

    #endregion Registration

    #region Helpers

    private static (Type serviceType, Type implementationType) GetTypes(Type serviceToRegister)
    {
        Type? genericInterface;

        // IDomainService, IUserRepo
        if (!serviceToRegister.IsGenericTypeDefinition)
        {
            genericInterface = serviceToRegister.GetInterfaces()
                .MaxBy(x => x.GetInterfaces().Length);

            return (genericInterface ?? serviceToRegister,
                serviceToRegister);
        }

        //Generic type like IRepository<T>, IReadOnlyRepository<T>
        genericInterface = serviceToRegister.GetInterfaces()
            .FirstOrDefault(x => x.IsGenericType && typeof(IServiced).IsAssignableFrom(x)); // this is the original

        return (genericInterface ?? serviceToRegister, serviceToRegister);
    }

    private static ServiceLifetime GetLifetime(Type serviceToRegister)
    {
        var lifetime = ServiceLifetime.Transient;

        if (typeof(IScoped).IsAssignableFrom(serviceToRegister))
            lifetime = ServiceLifetime.Scoped;
        else if (typeof(ISingleton).IsAssignableFrom(serviceToRegister)) lifetime = ServiceLifetime.Singleton;

        return lifetime;
    }

    private static IEnumerable<Assembly> FilterAssemblies(params Assembly[] assemblies)
    {
        var currentAssembly = Assembly.GetAssembly(typeof(IServiced));

        return assemblies.Where(x => x.FullName != currentAssembly!.FullName);
    }

    #endregion Helpers
}