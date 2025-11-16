namespace Contracts.Projects;

public sealed record ProjectWasNotDeleted
{
    public Guid ProjectId { get; init; }

    public string Reason { get; init; } = null!;
}