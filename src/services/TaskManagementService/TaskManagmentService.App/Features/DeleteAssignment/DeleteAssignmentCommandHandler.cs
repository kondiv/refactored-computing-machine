using Contracts.Assignment.Events;
using MassTransit;
using MediatR;
using TaskManagmentService.App.Domain.Enums;
using TaskManagmentService.App.Domain.ValueTypes.Result;
using TaskManagmentService.App.Domain.ValueTypes.Result.Errors;
using TaskManagmentService.App.Infrastructure;

namespace TaskManagmentService.App.Features.DeleteAssignment;

internal sealed class DeleteAssignmentCommandHandler : IRequestHandler<DeleteAssignmentCommand, Result>
{
    private readonly ServiceContext _context;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<DeleteAssignmentCommandHandler> _logger;

    public DeleteAssignmentCommandHandler(
        ServiceContext context,
        IPublishEndpoint publishEndpoint,
        ILogger<DeleteAssignmentCommandHandler> logger)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    public async Task<Result> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting assignment {id}", request.Id);

        var assignment = await _context
            .Assignments
            .FindAsync([request.Id], cancellationToken);

        if(assignment is null)
        {
            _logger.LogError("Cannot find assignment {id}", request.Id);
            return Result.Failure(new NotFoundError("Assignment not found"));
        }

        bool isValidStatus = IsValidStatus(assignment.AssignmentStatus); 

        if(!isValidStatus)
        {
            _logger.LogInformation("Current status doesn't allow delete operation for assignment. Status: {status}",
                assignment.AssignmentStatus.ToString());
            return Result.Failure(new DbUpdateError($"Cannot delete assignment with status {assignment.AssignmentStatus}"));
        }

        _context.Assignments.Remove(assignment);

        await _context.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Assingment {id} deleted", request.Id);

        await _publishEndpoint.Publish(new AssignmentDeletedEvent(
            assignment.Id,
            assignment.ProjectId,
            assignment.AssignmentGroupId,
            DateTime.UtcNow));

        return Result.Success();
    }

    private static bool IsValidStatus(AssignmentStatus status)
    {
        return status switch
        {
            AssignmentStatus.Backlog => true,
            AssignmentStatus.Current => true,
            AssignmentStatus.Canceled => true,
            AssignmentStatus.Completed => true,
            _ => false
        };
    }
}
