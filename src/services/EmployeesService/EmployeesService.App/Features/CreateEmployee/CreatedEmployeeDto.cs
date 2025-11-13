using EmployeesService.App.Domain.Enums;

namespace EmployeesService.App.Features.CreateEmployee;

public sealed record CreatedEmployeeDto(Guid Id, string Username, string Role, DateTime CreatedAtUtc);
