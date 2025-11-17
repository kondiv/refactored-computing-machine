using AssignmentGroupManagemetService.App.Domain.Result;
using MediatR;

namespace AssignmentGroupManagemetService.App.Features.GetAssignmentGroup;

internal sealed record GetAssignmentGroupRequest(Guid Id) : IRequest<Result<GetAssignmentGroupDto>>;
