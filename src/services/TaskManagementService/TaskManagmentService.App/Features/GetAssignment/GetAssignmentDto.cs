using TaskManagmentService.App.Domain.Entities;

namespace TaskManagmentService.App.Features.GetAssignment;

public sealed class GetAssignmentDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DeadlineUtc { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public string Status { get; set; } = null!;
    public string Priority { get; set; } = null!;
    public IEnumerable<Employee> Executors { get; set; } = [];
    public IEnumerable<Employee> Observers { get; set; } = [];
}

