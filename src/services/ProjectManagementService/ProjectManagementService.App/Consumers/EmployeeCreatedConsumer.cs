using Contracts.Employees;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ProjectManagementService.App.Domain.Entities;
using ProjectManagementService.App.Infrastructure;

namespace ProjectManagementService.App.Consumers;

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
        _logger.LogInformation("Creating employee {id}", context.Message.Id);

        var employee = new Employee
        {
            Id = context.Message.Id,
            Username = context.Message.Username,
            Role = context.Message.Role
        };

        await _context
            .Employees
            .AddAsync(employee, context.CancellationToken);

        try
        {
            await _context.SaveChangesAsync(context.CancellationToken);
            _logger.LogInformation("EmployeeCreated");
        }
        catch (DbUpdateException ex)
            when (ex.InnerException is NpgsqlException { SqlState: PostgresErrorCodes.UniqueViolation })
        {
            _logger.LogError("Possible duplicate message consumed");
            return;
        }
    }
}
