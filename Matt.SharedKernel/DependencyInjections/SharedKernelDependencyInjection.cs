using System.Reflection;
using FluentValidation;
using Mapster;
using MapsterMapper;
using Matt.SharedKernel.Application.Authorizations;
using Matt.SharedKernel.Application.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace Matt.SharedKernel.DependencyInjections;

public static class SharedKernelDependencyInjection
{
    public static IServiceCollection AddSharedKernel(this IServiceCollection services, params Assembly[] assemblies)
    {
        services
            .AddMediator(assemblies)
            .AddApplicationMappings(assemblies)
            .AddValidatorsFromAssemblies(assemblies);

        return services;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(assemblies);

            cfg.AddOpenBehavior(typeof(LoggingPipelineBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
        });

        return services;
    }

    private static IServiceCollection AddApplicationMappings(this IServiceCollection services,
        params Assembly[] assemblies)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(assemblies);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}