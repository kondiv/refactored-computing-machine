namespace TaskManagmentService.App.Features.CreateAssignment;

public class CreatedAssignmentDto
{
    public Guid Id { get; init; }

    public Guid ProjectId { get; init; }

    public Guid AssignmentGroupId { get; init; }

    public string Title { get; init; } = null!;
}
