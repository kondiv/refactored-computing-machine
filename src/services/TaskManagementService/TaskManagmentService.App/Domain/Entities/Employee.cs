namespace TaskManagmentService.App.Domain.Entities;

public sealed class Employee
{
    public Guid Id { get; init; }

    public string Username { get; init; } = null!;

    public string Role { get; init; } = null!;
}
