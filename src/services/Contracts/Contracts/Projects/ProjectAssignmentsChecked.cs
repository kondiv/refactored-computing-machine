namespace Contracts.Projects;

public sealed record ProjectAssignmentsChecked
{
    public Guid ProjectId { get; init; }
    
    public bool CanBeDeleted { get; init; }
}