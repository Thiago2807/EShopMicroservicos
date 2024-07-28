using BuildingBlocks.Messaging.MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;

namespace Ordening.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehaviors<,>));
        });

        services.AddFeatureManagement();

        services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());

        return services;
    }
}
