namespace TaskManagmentService.App.Features.CreateAssignment;

public sealed record CreateAssignmentApiRequest(
    string Title, 
    string Description,
    Guid ProjectId,
    Guid AssignmentGroupId, 
    DateTime DeadLineUtc,
    string AssignmentStatus,
    string Priority);
