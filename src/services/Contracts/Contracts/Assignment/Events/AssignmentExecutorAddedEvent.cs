namespace Contracts.Assignment.Events;

public sealed record AssignmentExecutorAddedEvent(Guid AssignmentId, Guid EmployeeId, Guid ProjectId, Guid AssignmentGroupId,
    DateTime AddedAtUtc);
