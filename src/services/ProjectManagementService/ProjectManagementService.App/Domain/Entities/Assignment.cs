namespace ProjectManagementService.App.Domain.Entities;

public class Assignment
{
    public Guid Id { get; init; }
    public Guid ProjectId { get; init; }
    public string Status { get; set; } = null!;
}
