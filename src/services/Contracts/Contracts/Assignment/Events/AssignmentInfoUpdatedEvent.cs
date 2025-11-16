namespace Contracts.Assignment.Events;
public sealed record AssignmentInfoUpdatedEvent(Guid AssignmentId, Guid ProjectId, Guid AssignmentGroupId, DateTime UpdatedAtUtc);
