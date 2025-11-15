namespace Contracts.Assignment.Events;

public sealed record AssignmentDeletedEvent(Guid Id, Guid ProjectId, Guid AssignmentGroupId, DateTime DeletedAtUtc);
