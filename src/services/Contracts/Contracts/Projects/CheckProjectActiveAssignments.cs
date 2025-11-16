namespace Contracts.Projects;

public sealed record CheckProjectActiveAssignments
{
    public Guid ProjectId { get; init; }
}