namespace Contracts.Assignment.Events;

public sealed record AssignmentObserverAddedEvent(Guid AssignmentId, Guid EmployeeId, Guid ProjectId, Guid AssignmentGroupId,
    DateTime AddedAtUtc);
