using TaskManagmentService.App.Domain.Enums;

namespace TaskManagmentService.App.Domain.Entities;

public sealed class Assignment
{
    public Guid Id { get; init; }

    public string Title { get; set; } = null!;
    
    public string Description { get; set; } = null!;

    public Guid ProjectId { get; init; }

    public Guid AssignmentGroupId { get; init; }

    public DateTime DeadlineUtc { get; init; }

    public DateTime CreatedAtUtc { get; set; }

    public AssignmentStatus AssignmentStatus { get; set; }

    public Priority Priority { get; set; }

    public ICollection<AssignmentEmployee> AssignmentEmployees { get; set; } = [];

    public IEnumerable<AssignmentEmployee> Executors => 
        AssignmentEmployees.Where(ae => ae.AssignmentRole == AssignmentRole.Executor);
    
    public IEnumerable<AssignmentEmployee> Observers => 
        AssignmentEmployees.Where(ae => ae.AssignmentRole == AssignmentRole.Observer);
}
