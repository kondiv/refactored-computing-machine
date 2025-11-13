namespace EmployeesService.App.Features.GetEmployee;

public sealed class GetEmployeeDto
{
    public Guid Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Username { get; set; } = null!;

    public string Role { get; set; } = null!;
}
