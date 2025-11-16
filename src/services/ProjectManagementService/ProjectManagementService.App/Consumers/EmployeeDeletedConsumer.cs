using Contracts.Employees;
using MassTransit;
using ProjectManagementService.App.Infrastructure;

namespace ProjectManagementService.App.Consumers;

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
        _logger.LogInformation("Employee {id} deleted. Deleting employee from Project Management Service",
            context.Message.Id);

        var employee = await _context
            .Employees
            .FindAsync([context.Message.Id], context.CancellationToken);

        if(employee is null)
        {
            _logger.LogError("Employee {id} not found. Apparently EmployeeCreated is not proccessed yet" +
                "or EmployeeDeleted duplicate came", context.Message.Id);
            return;
        }

        _context
            .Employees
            .Remove(employee);

        await _context.SaveChangesAsync(context.CancellationToken);

        _logger.LogInformation("Employee {id} successfully deleted", context.Message.Id);
    } 
}
