namespace Contracts.Assignment.Events;
public sealed record AssignmentInfoUpdatedEvent(Guid Id, Guid ProjectId, Guid AssignmentGroupId, DateTime UpdatedAtUtc);
