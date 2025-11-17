using AssignmentGroupManagemetService.App.Domain.Result;
using AssignmentGroupManagemetService.App.Domain.Result.Errors;
using AssignmentGroupManagemetService.App.Infrastructure;
using Contracts.AssignmentGroup;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AssignmentGroupManagemetService.App.Features.DeleteAssignmentGroup;

internal sealed class DeleteAssignmentGroupCommandHandler : IRequestHandler<DeleteAssignmentGroupCommand, Result>
{
    private readonly ServiceContext _context;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<DeleteAssignmentGroupCommandHandler> _logger;

    public DeleteAssignmentGroupCommandHandler(
        ServiceContext context,
        IPublishEndpoint publishEndpoint,
        ILogger<DeleteAssignmentGroupCommandHandler> logger)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    public async Task<Result> Handle(DeleteAssignmentGroupCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Delete assignment group {id}", request.Id);

        var assignmentGroup = await _context
            .AssignmentGroups
            .FindAsync([request.Id], cancellationToken);

        if(assignmentGroup is null)
        {
            _logger.LogError("Cannot find assignment group with id {id}", request.Id);
            return Result.Failure(new NotFoundError("Assignment group not found"));
        }

        bool hasAnyUnfinished = await _context
            .Assignments
            .AnyAsync(a => a.AssignmentGroupId == request.Id && a.Status.ToLower() != "canceled", cancellationToken);

        if (hasAnyUnfinished)
        {
            _logger.LogError("The assignment {id} group has unfinished assignments", request.Id);
            return Result.Failure(new DbUpdateError("The assignment group has unfinished assignments"));
        }

        _context
            .AssignmentGroups
            .Remove(assignmentGroup);

        await _context.SaveChangesAsync(cancellationToken);

        await _publishEndpoint.Publish(new AssignmentGroupDeleted(assignmentGroup.Id, DateTime.UtcNow));

        _logger.LogInformation("Assignment group {id} successfully deleted", request.Id);
        return Result.Success();
    }
}
