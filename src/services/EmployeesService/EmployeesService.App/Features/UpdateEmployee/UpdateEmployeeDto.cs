namespace EmployeesService.App.Features.UpdateEmployee;

public sealed record UpdateEmployeeDto(string Surname, string Name, string? Patronymic, string Username, string Role);
