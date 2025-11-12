namespace EmployeesService.App.Features.CreateEmployee;

public sealed record CreateEmployeeRequestDto(string Surname, string Name, string? Patronymic,
    string Username, string Role);
