using MediatR;
using TaskManagmentService.App.Domain.ValueTypes.Result;

namespace TaskManagmentService.App.Features.CreateAssignment;

internal sealed record CreateAssignmentCommand(
    string Title,
    string Description,
    Guid ProjectId,
    Guid AssignmentGroupId,
    DateTime DeadLineUtc,
    string AssignmentStatus,
    string Priority) : IRequest<Result<CreatedAssignmentDto>>;

