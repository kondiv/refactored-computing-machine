using EmployeesService.App.Domain.Enums;
using EmployeesService.App.Features.UpdateEmployee;

namespace EmployeesService.App.Domain.Entities;

public class Employee
{
    public Guid Id { get; init; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Username { get; set; } = null!;

    public Role Role { get; set; }

    public Employee()
    {
        
    }

    public Employee(string surname, string name, string? patronymic, string username, Role role)
    {
        Id = Guid.NewGuid();
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
        Username = username;
        Role = role;
    }

    public void Update(UpdateEmployeeDto updateEmployee)
    {
        Surname = updateEmployee.Surname;
        Name = updateEmployee.Name;
        Patronymic = updateEmployee.Patronymic;
        Username = updateEmployee.Username;
        Role = (Role)Enum.Parse(typeof(Role), updateEmployee.Role);
    }
}
