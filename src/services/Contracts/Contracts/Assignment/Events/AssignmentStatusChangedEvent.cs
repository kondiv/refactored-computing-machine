namespace Contracts.Assignment.Events;

public sealed record AssignmentStatusChangedEvent(Guid AssignmentId, Guid ProjectId, Guid AssignmentGroupId,
    string FromStatus, string ToStatus);
