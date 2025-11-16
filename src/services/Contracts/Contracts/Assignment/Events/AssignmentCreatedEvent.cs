namespace Contracts.Assignment.Events;

public sealed record AssignmentCreatedEvent(Guid AssignmentId, string Title, Guid ProjectId, Guid AssignmentGroupId, 
    string Status, DateTime CreatedAtUtc);
