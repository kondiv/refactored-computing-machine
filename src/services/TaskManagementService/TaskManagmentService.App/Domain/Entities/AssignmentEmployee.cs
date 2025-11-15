using TaskManagmentService.App.Domain.Enums;

namespace TaskManagmentService.App.Domain.Entities;

public class AssignmentEmployee
{
    public Guid EmployeeId { get; init; }

    public Guid AssignmentId { get; init; }

    public AssignmentRole AssignmentRole { get; set; }

    public Employee Employee { get; set; } = null!;

    public Assignment Assignment { get; set; } = null!;
}
