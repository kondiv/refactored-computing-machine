using Contracts.Assignment.Events;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagmentService.App.Domain.Enums;
using TaskManagmentService.App.Domain.ValueTypes.Result;
using TaskManagmentService.App.Domain.ValueTypes.Result.Errors;
using TaskManagmentService.App.Infrastructure;

namespace TaskManagmentService.App.Features.ChangeStatus;

internal sealed class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, Result>
{
    private readonly ServiceContext _context;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IValidator<ChangeStatusCommand> _validator;
    private readonly ILogger<ChangeStatusCommandHandler> _logger;

    public ChangeStatusCommandHandler(
        ServiceContext context,
        IPublishEndpoint publishEndpoint,
        IValidator<ChangeStatusCommand> validator,
        ILogger<ChangeStatusCommandHandler> logger)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;
        _validator = validator;
        _logger = logger;
    }

    public async Task<Result> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Changing assignment {id} status", request.Id);

        await _validator.ValidateAndThrowAsync(request);

        var assignment = await _context
            .Assignments
            .FindAsync([request.Id], cancellationToken);

        if(assignment is null)
        {
            _logger.LogError("Cannot fing assignment {id}", request.Id);
            return Result.Failure(new NotFoundError("Assignment not found"));
        }

        var currentStatus = assignment.AssignmentStatus;
        var newStatus = Enum.Parse<AssignmentStatus>(request.Status, ignoreCase: true);

        if(!IsValidChange(currentStatus, newStatus))
        {
            _logger.LogError("Invalid status provided. Cannot switch from {currentStatus} to {newStatus}",
                currentStatus.ToString(), newStatus.ToString());
            return Result.Failure(new DbUpdateError("Invalid status provided"));
        }

        assignment.AssignmentStatus = newStatus;

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logger.LogError(ex, "Status has been already changed since current request started");
            return Result.Failure(new DbUpdateConcurrencyError("Status has already been updated. Try again"));
        }

        await _publishEndpoint.Publish(new AssignmentStatusChangedEvent(
            assignment.Id,
            assignment.ProjectId,
            assignment.AssignmentGroupId,
            currentStatus.ToString(),
            newStatus.ToString()));

        _logger.LogInformation("Assignment {id} status changed", request.Id);

        return Result.Success();
    }

    private static bool IsValidChange(AssignmentStatus currentStatus, AssignmentStatus newStatus)
    {
        if(newStatus == AssignmentStatus.Canceled)
        {
            return true;
        }

        return (currentStatus, newStatus) switch
        {
            (AssignmentStatus.Backlog, AssignmentStatus.Current) => true,
            (AssignmentStatus.Current, AssignmentStatus.Active) => true,
            (AssignmentStatus.Active, AssignmentStatus.Testing) => true,
            (AssignmentStatus.Testing, AssignmentStatus.Active) => true,
            (AssignmentStatus.Testing, AssignmentStatus.Completed) => true,
            _ => false
        };
    }
}