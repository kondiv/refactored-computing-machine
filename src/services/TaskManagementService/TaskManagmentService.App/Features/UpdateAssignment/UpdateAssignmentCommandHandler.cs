using Contracts.Assignment.Events;
using FluentValidation;
using MassTransit;
using MediatR;
using TaskManagmentService.App.Domain.Enums;
using TaskManagmentService.App.Domain.ValueTypes.Result;
using TaskManagmentService.App.Domain.ValueTypes.Result.Errors;
using TaskManagmentService.App.Infrastructure;

namespace TaskManagmentService.App.Features.UpdateAssignment;

internal sealed class UpdateAssignmentCommandHandler : IRequestHandler<UpdateAssignmentCommand, Result>
{
    private readonly ServiceContext _context;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IValidator<UpdateAssignmentDto> _validator;
    private readonly ILogger<UpdateAssignmentCommandHandler> _logger;

    public UpdateAssignmentCommandHandler(
        ServiceContext context,
        IPublishEndpoint publishEndpoint,
        IValidator<UpdateAssignmentDto> validator,
        ILogger<UpdateAssignmentCommandHandler> logger)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;
        _validator = validator;
        _logger = logger;
    }

    public async Task<Result> Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating assignment {id} info", request.Id);

        var assignment = await _context
            .Assignments
            .FindAsync([request.Id], cancellationToken);

        if (assignment is null)
        {
            _logger.LogError("Cannot find assignment {id}", request.Id);
            return Result.Failure(new NotFoundError("Assignment nof found"));
        }

        var updateAssignmentDto = new UpdateAssignmentDto(
            assignment.Title,
            assignment.Description,
            assignment.Priority.ToString());

        request.PatchDocument.ApplyTo(updateAssignmentDto);

        await _validator.ValidateAndThrowAsync(updateAssignmentDto, cancellationToken);

        assignment.Title = updateAssignmentDto.Title;
        assignment.Description = updateAssignmentDto.Description;
        assignment.Priority = Enum.Parse<Priority>(updateAssignmentDto.Priority, ignoreCase: true);

        await _context.SaveChangesAsync(cancellationToken);

        await _publishEndpoint.Publish(new AssignmentInfoUpdatedEvent(
            assignment.Id,
            assignment.ProjectId,
            assignment.AssignmentGroupId,
            DateTime.UtcNow));

        _logger.LogInformation("Assignment {id} info updated successfully", request.Id);

        return Result.Success();
    }
}
