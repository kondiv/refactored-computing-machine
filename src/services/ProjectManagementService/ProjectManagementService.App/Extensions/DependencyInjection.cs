using MassTransit;
using ProjectManagementService.App.Consumers;

namespace ProjectManagementService.App.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddRabbitMQ(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.AddConsumer<AssignmentStatusChangedConsumer>();
            busConfigurator.AddConsumer<AssignmentCreatedConsumer>();
            busConfigurator.AddConsumer<AssignmentDeletedConsumer>();
            busConfigurator.AddConsumer<EmployeeCreatedConsumer>();
            busConfigurator.AddConsumer<EmployeeDeletedConsumer>();

            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(configuration["MessageBroker:Host"]!), h =>
                {
                    h.Username(configuration["MessageBroker:Username"]!);
                    h.Password(configuration["MessageBroker:Password"]!);
                });

                configurator.ReceiveEndpoint("project-management-service-assignment-status-changed", e =>
                {
                    e.ConfigureConsumer<AssignmentStatusChangedConsumer>(context);
                });
                configurator.ReceiveEndpoint("project-management-service-assignment-created", e =>
                {
                    e.ConfigureConsumer<AssignmentCreatedConsumer>(context);
                });
                configurator.ReceiveEndpoint("project-management-service-assignment-deleted", e =>
                {
                    e.ConfigureConsumer<AssignmentDeletedConsumer>(context);
                });
                configurator.ReceiveEndpoint("project-management-service-assignment-employee-created", e =>
                {
                    e.ConfigureConsumer<EmployeeCreatedConsumer>(context);
                });
                configurator.ReceiveEndpoint("project-management-service-assignment-employee-deleted", e =>
                {
                    e.ConfigureConsumer<EmployeeDeletedConsumer>(context);
                });
                configurator.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
