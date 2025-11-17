using Contracts.Employees;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using TaskManagmentService.App.Domain.Entities;
using TaskManagmentService.App.Infrastructure;

namespace TaskManagmentService.App.Consumers;

internal sealed class EmployeeCreatedConsumer : IConsumer<EmployeeCreated>
{
    private readonly ServiceContext _context;
    private readonly ILogger<EmployeeCreatedConsumer> _logger;

    public EmployeeCreatedConsumer(ServiceContext context, ILogger<EmployeeCreatedConsumer> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<EmployeeCreated> context)
    {
        _logger.LogInformation("EmployeeCreated message recieved. Creating new consumer");

        var employee = new Employee
        {
            Id = context.Message.Id,
            Username = context.Message.Username,
            Role = context.Message.Role,
        };

        await _context.Employees.AddAsync(employee, context.CancellationToken);

        try
        {
            await _context.SaveChangesAsync(context.CancellationToken);

            _logger.LogInformation("User {username} {role} successfully created", employee.Username, employee.Role);
        }
        catch (DbUpdateException ex)
            when (ex.InnerException is NpgsqlException { SqlState: PostgresErrorCodes.UniqueViolation }) 
        {
            _logger.LogWarning(ex.InnerException, "Employee already exists, possible message duplicate recieved");
        }
    }
}
