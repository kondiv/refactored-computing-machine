using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProjectManagementService.App.Consumers;
using ProjectManagementService.App.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ServiceContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(options =>
    options.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    busConfigurator.AddConsumer<AssignmentStatusChangedConsumer>();
    busConfigurator.AddConsumer<AssignmentCreatedConsumer>();
    busConfigurator.AddConsumer<AssignmentDeletedConsumer>();
    busConfigurator.AddConsumer<EmployeeCreatedConsumer>();
    busConfigurator.AddConsumer<EmployeeDeletedConsumer>();

    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(new Uri(builder.Configuration["MessageBroker:Host"]!), h =>
        {
            h.Username(builder.Configuration["MessageBroker:Username"]!);
            h.Password(builder.Configuration["MessageBroker:Password"]!);
        });

        configurator.ConfigureEndpoints(context);
    });
});

builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ServiceContext>();
    context.Database.Migrate();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
