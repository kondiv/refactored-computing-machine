using EmployeesService.App.Domain.Entities;
using EmployeesService.App.Domain.Enums;
using EmployeesService.App.Domain.ValueTypes.Result;
using EmployeesService.App.Domain.ValueTypes.Result.Errors;
using EmployeesService.App.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data.SqlTypes;

namespace EmployeesService.App.Features.CreateEmployee;

internal sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<CreatedEmployeeDto>>
{
    private readonly ApplicationContext _context;
    private readonly IValidator<CreateEmployeeCommand> _validator;
    private readonly ILogger<CreateEmployeeCommandHandler> _logger;

    public CreateEmployeeCommandHandler(
        ApplicationContext context,
        IValidator<CreateEmployeeCommand> validator,
        ILogger<CreateEmployeeCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
        _validator = validator;
    }

    public async Task<Result<CreatedEmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new employee. Username: {username}", request.Username);

        await _validator.ValidateAndThrowAsync(request);

        var role = (Role)Enum.Parse(typeof(Role), request.Role);

        var employee = new Employee(request.Surname, request.Name, request.Patronymic, request.Username, role);

        await _context.Employees.AddAsync(employee, cancellationToken);

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Employee {username} created", request.Username);

            return Result<CreatedEmployeeDto>.Success(
                new CreatedEmployeeDto(
                    employee.Id,
                    employee.Username,
                    employee.Role,
                    DateTime.UtcNow));
        }

        catch (DbUpdateException ex)
            when (ex.InnerException is NpgsqlException { SqlState: PostgresErrorCodes.UniqueViolation })
        {
            _logger.LogError(ex.InnerException, "Cannot create employee {username}. Because this username is already taken",
                request.Username);
            return Result<CreatedEmployeeDto>.Failure(new DbUpdateError("Username is already taken"));
        }
    }
}
