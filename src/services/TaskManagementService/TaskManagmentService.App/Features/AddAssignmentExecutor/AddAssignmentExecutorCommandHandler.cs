using Contracts.Assignment.Events;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagmentService.App.Domain.Entities;
using TaskManagmentService.App.Domain.Enums;
using TaskManagmentService.App.Domain.ValueTypes.Result;
using TaskManagmentService.App.Domain.ValueTypes.Result.Errors;
using TaskManagmentService.App.Infrastructure;

namespace TaskManagmentService.App.Features.AddAssignmentExecutor;

internal sealed class AddAssignmentExecutorCommandHandler : IRequestHandler<AddAssignmentExecutorCommand, Result>
{
    private readonly ServiceContext _context;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<AddAssignmentExecutorCommandHandler> _logger;

    public AddAssignmentExecutorCommandHandler(
        ServiceContext context,
        IPublishEndpoint publishEndpoint,
        ILogger<AddAssignmentExecutorCommandHandler> logger)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    public async Task<Result> Handle(AddAssignmentExecutorCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Adding executor to the assignment {id}", request.AssignmentId);

        bool alreadyInAssignment = await _context
            .AssignmentEmployees
            .AnyAsync(ae => ae.AssignmentId == request.AssignmentId && ae.EmployeeId == request.EmployeeId, cancellationToken);

        if (alreadyInAssignment)
        {
            _logger.LogError("Employee already takes part in assignment.\nAssingment {assignmentId}\nEmployee {employeeId}",
                request.AssignmentId, request.EmployeeId);
            return Result.Failure(new DbUpdateError("Employee already takes part in assignment"));
        }

        bool employeeExist = await _context
            .Employees
            .AnyAsync(e => e.Id == request.EmployeeId, cancellationToken);

        if (!employeeExist)
        {
            _logger.LogError("Cannot fing employee with id {id}", request.EmployeeId);
            return Result.Failure(new NotFoundError("Employee not found"));
        }

        var assignment = await _context
            .Assignments
            .Select(a => new
            {
                a.Id,
                a.ProjectId,
                a.AssignmentGroupId
            })
            .FirstOrDefaultAsync(a => a.Id == request.AssignmentId, cancellationToken);

        if (assignment is null)
        {
            _logger.LogError("Cannot fing assingment with id {id}", request.AssignmentId);
            return Result.Failure(new NotFoundError("Assignment not found"));
        }

        var assignmentEmployee = new AssignmentEmployee
        {
            AssignmentId = request.AssignmentId,
            EmployeeId = request.EmployeeId,
            AssignmentRole = AssignmentRole.Executor
        };

        await _context
            .AssignmentEmployees
            .AddAsync(assignmentEmployee, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        await _publishEndpoint.Publish(new AssignmentExecutorAddedEvent(
            assignment.Id,
            request.EmployeeId,
            assignment.ProjectId,
            assignment.AssignmentGroupId,
            DateTime.UtcNow));

        return Result.Success();
    }
}
