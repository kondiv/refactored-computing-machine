using AssignmentGroupManagemetService.App.Domain.Result;
using AssignmentGroupManagemetService.App.Domain.Result.Errors;
using AssignmentGroupManagemetService.App.Infrastructure;
using MediatR;

namespace AssignmentGroupManagemetService.App.Features.UpdateAssignmentGroup;

internal sealed class UpdateAssignmentGroupCommandHandler : IRequestHandler<UpdateAssignmentGroupCommand, Result>
{
    private readonly ServiceContext _context;
    private readonly ILogger<UpdateAssignmentGroupCommandHandler> _logger;

    public UpdateAssignmentGroupCommandHandler(ServiceContext context, ILogger<UpdateAssignmentGroupCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Result> Handle(UpdateAssignmentGroupCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating assignment group {id}", request.Id);

        var assignmentGroup = await _context
            .AssignmentGroups
            .FindAsync([request.Id], cancellationToken);

        if(assignmentGroup is null)
        {
            _logger.LogError("Cannot find assignment group with id {id}", request.Id);
            return Result.Failure(new NotFoundError("Assignment group not found"));
        }

        var updateAssignmentGroupDto = new UpdateAssignmentGroupDto
        {
            Name = assignmentGroup.Name
        };

        request.PatchDocument.ApplyTo(updateAssignmentGroupDto);

        assignmentGroup.Name = updateAssignmentGroupDto.Name;

        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Assignment group successfully updated {id}", assignmentGroup.Id);
        return Result.Success();
    }
}
