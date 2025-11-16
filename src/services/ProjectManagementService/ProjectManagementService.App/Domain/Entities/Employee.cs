namespace ProjectManagementService.App.Domain.Entities;

public sealed class Employee
{
    public Guid Id { get; init; }

    public string Username { get; set; } = null!;

    public string Role { get; set; } = null!;
}
