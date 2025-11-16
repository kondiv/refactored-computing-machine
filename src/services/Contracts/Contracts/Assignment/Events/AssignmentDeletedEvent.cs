namespace Contracts.Assignment.Events;

public sealed record AssignmentDeletedEvent(Guid AssignmentId, Guid ProjectId, Guid AssignmentGroupId, DateTime DeletedAtUtc);
