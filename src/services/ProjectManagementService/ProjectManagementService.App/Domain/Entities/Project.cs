namespace ProjectManagementService.App.Domain.Entities;

public sealed class Project
{
    public Guid Id { get; init; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid SupervisorId { get; set; }

    public Employee Supervisor { get; set; } = null!;

    public Guid ManagerId { get; set; }

    public Employee Manager { get; set; } = null!;
}
