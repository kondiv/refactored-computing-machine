using Contracts.Assignment.Events;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagmentService.App.Domain.Entities;
using TaskManagmentService.App.Domain.ValueTypes.Result;
using TaskManagmentService.App.Domain.ValueTypes.Result.Errors;
using TaskManagmentService.App.Infrastructure;

namespace TaskManagmentService.App.Features.AddAssignmentObserver;

internal sealed class AddAssignmentObserverCommandHandler : IRequestHandler<AddAssignmentObserverCommand, Result>
{
    private readonly ServiceContext _context;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<AddAssignmentObserverCommandHandler> _logger;

    public AddAssignmentObserverCommandHandler(
        ServiceContext context,
        IPublishEndpoint publishEndpoint,
        ILogger<AddAssignmentObserverCommandHandler> logger)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    public async Task<Result> Handle(AddAssignmentObserverCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Adding assingment {id} observer", request.AssignmentId);

        bool exist = await _context
            .AssignmentEmployees
            .AnyAsync(ae => ae.AssignmentId == request.AssignmentId && ae.EmployeeId == request.EmployeeId, cancellationToken);

        if(exist)
        {
            _logger.LogError("Employee already takes part in the assignment.\nAssignment {assignmentId}\nEmployee {employeeId}",
                request.AssignmentId, request.EmployeeId);
            return Result.Failure(new DbUpdateError("Employee already takes part in the assignment"));
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

        if(assignment is null)
        {
            _logger.LogError("Cannot find assignment with id {id}", request.AssignmentId);
            return Result.Failure(new NotFoundError("Assignment not found"));
        }

        bool employeeExist = await _context
            .Employees
            .AnyAsync(e => e.Id == request.EmployeeId, cancellationToken);

        if(!employeeExist)
        {
            _logger.LogError("Cannot find employee with id {id}", request.EmployeeId);
            return Result.Failure(new NotFoundError("Employee not found"));
        }

        var assignmentEmployee = new AssignmentEmployee
        {
            AssignmentId = request.AssignmentId,
            EmployeeId = request.EmployeeId,
            AssignmentRole = Domain.Enums.AssignmentRole.Observer
        };

        await _context
            .AssignmentEmployees
            .AddAsync(assignmentEmployee, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        await _publishEndpoint.Publish(new AssignmentObserverAddedEvent(
            assignment.Id,
            request.EmployeeId,
            assignment.ProjectId,
            assignment.AssignmentGroupId,
            DateTime.UtcNow));

        return Result.Success();
    }
}
