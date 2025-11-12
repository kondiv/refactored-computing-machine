namespace EmployeesService.App.Features.GetEmployee;

public sealed record GetEmployeeDto(Guid Id, string Surname, string Name, string? Patronymic,
    string Username, string Role);
