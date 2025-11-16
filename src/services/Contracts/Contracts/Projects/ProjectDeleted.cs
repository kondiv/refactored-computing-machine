namespace Contracts.Projects;

public sealed record ProjectDeleted
{
    public Guid ProjectId { get; init; }
}