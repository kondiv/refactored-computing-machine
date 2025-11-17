using AssignmentGroupManagemetService.App.Consumers;
using MassTransit;

namespace AssignmentGroupManagemetService.App.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddRabbitMQ(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.AddConsumer<AssignmentCreatedConsumer>();
            busConfigurator.AddConsumer<AssignmentDeletedConsumer>();
            busConfigurator.AddConsumer<AssignmentStatusChangedConsumer>();

            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(configuration["MessageBroker:Host"]!), h =>
                {
                    h.Username(configuration["MessageBroker:Username"]!);
                    h.Password(configuration["MessageBroker:Password"]!);
                });

                configurator.ReceiveEndpoint("assignment-group-service-assignment-deleted", e =>
                {
                    e.PrefetchCount = 20;
                    e.ConcurrentMessageLimit = 10;

                    e.ConfigureConsumer<AssignmentDeletedConsumer>(context);

                    e.UseMessageRetry(r => r.Interval(3, 1000));
                });

                configurator.ReceiveEndpoint("assignment-group-service-assignment-status-changed", e =>
                {
                    e.PrefetchCount = 20;
                    e.ConcurrentMessageLimit = 10;

                    e.ConfigureConsumer<AssignmentStatusChangedConsumer>(context);

                    e.UseMessageRetry(r => r.Interval(3, 1000));
                });

                configurator.ReceiveEndpoint("assignment-group-service-assignment-created", e =>
                {
                    e.PrefetchCount = 20;
                    e.ConcurrentMessageLimit = 10;

                    e.ConfigureConsumer<AssignmentCreatedConsumer>(context);

                    e.UseMessageRetry(r => r.Interval(3, 1000));
                });

                configurator.ConfigureEndpoints(context);
            });
        });
        return services;
    }
}
