namespace Contracts.Projects;

public sealed record ProjectDeletionInitialized
{
    public Guid ProjectId { get; init; }
}