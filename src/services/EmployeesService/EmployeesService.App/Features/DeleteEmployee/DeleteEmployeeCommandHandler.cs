using EmployeesService.App.Domain.ValueTypes.Result;
using EmployeesService.App.Domain.ValueTypes.Result.Errors;
using EmployeesService.App.Infrastructure;
using MediatR;

namespace EmployeesService.App.Features.DeleteEmployee;

internal sealed class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Result>
{
    private readonly ApplicationContext _context;
    private readonly ILogger<DeleteEmployeeCommandHandler> _logger;

    public DeleteEmployeeCommandHandler(ApplicationContext context, ILogger<DeleteEmployeeCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Result> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting employee {id}", request.Id);

        var employee = await _context
            .Employees
            .FindAsync([request.Id], cancellationToken);

        if(employee is null)
        {
            _logger.LogError("Employee {id} not found", request.Id);
            return Result.Failure(new NotFoundError("Employee not found"));
        }

        _context.Employees.Remove(employee);

        await _context.SaveChangesAsync();

        _logger.LogInformation("Employee {id} successfully deleted", request.Id);
        return Result.Success();
    }
}
