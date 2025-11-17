using FluentValidation;
using MassTransit;
using TaskManagmentService.App.Consumers;

namespace TaskManagmentService.App.Extensions;

internal static class DependecyInjection
{
    public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.AddConsumer<EmployeeCreatedConsumer>();
            busConfigurator.AddConsumer<EmployeeDeletedConsumer>();
            busConfigurator.AddConsumer<AssignmentGroupCreatedConsumer>();
            busConfigurator.AddConsumer<AssignmentGroupDeletedConsumer>();
            busConfigurator.AddConsumer<ProjectCreatedConsumer>();
            busConfigurator.AddConsumer<ProjectDeletedConsumer>();

            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(configuration["MessageBroker:Host"]!), h =>
                {
                    h.Username(configuration["MessageBroker:Username"]!);
                    h.Password(configuration["MessageBroker:Password"]!);
                });

                configurator.ReceiveEndpoint("task-management-service-employee-created", e =>
                {
                    e.ConfigureConsumer<EmployeeCreatedConsumer>(context);
                });
                
                configurator.ReceiveEndpoint("task-management-service-employee-deleted", e =>
                {
                    e.ConfigureConsumer<EmployeeDeletedConsumer>(context);
                });

                configurator.ReceiveEndpoint("task-management-service-assignment-group-created", e =>
                {
                    e.ConfigureConsumer<AssignmentGroupCreatedConsumer>(context);
                });

                configurator.ReceiveEndpoint("task-management-service-assignment-group-deleted", e =>
                {
                    e.ConfigureConsumer<AssignmentGroupDeletedConsumer>(context);
                });

                configurator.ReceiveEndpoint("task-management-service-project-created", e =>
                {
                    e.ConfigureConsumer<ProjectCreatedConsumer>(context);
                });
                
                configurator.ReceiveEndpoint("task-management-service-project-deleted", e =>
                {
                    e.ConfigureConsumer<ProjectDeletedConsumer>(context);
                });

                configurator.ConfigureEndpoints(context);
            });
        });

        return services;
    }

    public static IServiceCollection AddMediatr(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(typeof(Program).Assembly));
        return services;
    }

    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(Program).Assembly, includeInternalTypes: true);
        
        return services;
    }
}
