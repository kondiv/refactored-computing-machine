using MediatR;
using TaskManagmentService.App.Features.GetAssignment;

namespace TaskManagmentService.App.Features.ListAssignments;

internal sealed record ListAssignmentsRequest(int Page, int MaxPageSize,
    Guid? EmployeeId, Guid? AssignmentGroupId, Guid? ProjectId) : IRequest<IReadOnlyList<GetAssignmentDto>>;

