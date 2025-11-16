namespace Contracts.Projects;

public sealed record DeleteProject
{
    public Guid ProjectId { get; init; }
}