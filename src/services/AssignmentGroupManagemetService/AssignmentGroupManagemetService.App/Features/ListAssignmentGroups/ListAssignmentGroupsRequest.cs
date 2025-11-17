using AssignmentGroupManagemetService.App.Features.GetAssignmentGroup;
using MediatR;

namespace AssignmentGroupManagemetService.App.Features.ListAssignmentGroups;

internal sealed record ListAssignmentGroupsRequest(int Page, int MaxPageSize) 
    : IRequest<IReadOnlyList<GetAssignmentGroupDto>>;
