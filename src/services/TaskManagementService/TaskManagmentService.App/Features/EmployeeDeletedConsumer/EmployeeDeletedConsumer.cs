using Contracts.Employees;
using MassTransit;
using TaskManagmentService.App.Infrastructure;

namespace TaskManagmentService.App.Features.EmployeeDeletedConsumer;

internal sealed class EmployeeDeletedConsumer : IConsumer<EmployeeDeleted>
{
    private readonly ServiceContext _context;
    private readonly ILogger<EmployeeDeletedConsumer> _logger;

    public EmployeeDeletedConsumer(ServiceContext context, ILogger<EmployeeDeletedConsumer> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<EmployeeDeleted> context)
    {
        _logger.LogInformation("EmployeeDeleted message recieved. Deleting employee");

        var employee = await _context
            .Employees
            .FindAsync(context.Message.Id, context.CancellationToken);

        if(employee is null)
        {
            _logger.LogError("Employee does not exist. Duplicate message recieved or UserCreated will come later");
            return;
        }

        _context.Employees.Remove(employee);

        await _context.SaveChangesAsync(context.CancellationToken);

        _logger.LogInformation("Employee {id} successfully deleted", context.Message.Id);
    }
}
