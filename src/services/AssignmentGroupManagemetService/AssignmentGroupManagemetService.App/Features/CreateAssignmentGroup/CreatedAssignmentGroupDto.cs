namespace AssignmentGroupManagemetService.App.Features.CreateAssignmentGroup;

public sealed class CreatedAssignmentGroupDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public DateTime CreatedAtUtc { get; init; }
}
