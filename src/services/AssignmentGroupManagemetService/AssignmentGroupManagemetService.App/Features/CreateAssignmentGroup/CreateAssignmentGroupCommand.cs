using AssignmentGroupManagemetService.App.Domain.Result;
using MediatR;

namespace AssignmentGroupManagemetService.App.Features.CreateAssignmentGroup;

internal sealed record CreateAssignmentGroupCommand(string Name) : IRequest<Result<CreatedAssignmentGroupDto>>;

