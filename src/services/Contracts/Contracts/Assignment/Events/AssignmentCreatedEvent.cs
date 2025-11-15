namespace Contracts.Assignment.Events;

public sealed record AssignmentCreatedEvent(string Title, Guid ProjectId, Guid AssignmentGroupId, DateTime CreatedAtUtc);
