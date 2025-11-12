using EmployeesService.App.Domain.ValueTypes.Result;
using MediatR;

namespace EmployeesService.App.Features.CreateEmployee;

internal sealed record CreateEmployeeCommand : IRequest<Result<CreatedEmployeeDto>>
{
    public string Surname { get; init; }
    
    public string Name { get; init; }

    public string? Patronymic { get; init; }

    public string Username { get; init; }

    public string Role { get; init; }

    public CreateEmployeeCommand(string surname, string name, string? patronymic, string username, string role)
    {
        Surname = surname.Trim();
        Name = name.Trim();
        Patronymic = patronymic?.Trim();
        Username = username.Trim();
        Role = role.Trim();
    }
}

