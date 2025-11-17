namespace AssignmentGroupManagemetService.App.Domain.Entities;

internal sealed class Assignment
{
    public Guid Id { get; set; }

    public Guid AssignmentGroupId{ get; set; }

    public string Status { get; set; } = null!;
}
