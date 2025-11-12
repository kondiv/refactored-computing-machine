using EmployeesService.App.Domain.ValueTypes.Result;
using EmployeesService.App.Domain.ValueTypes.Result.Errors;
using EmployeesService.App.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace EmployeesService.App.Features.UpdateEmployee;

internal sealed class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Result>
{
    private readonly ApplicationContext _context;
    private readonly IValidator<UpdateEmployeeDto> _validator;
    private readonly ILogger<UpdateEmployeeCommandHandler> _logger;

    public UpdateEmployeeCommandHandler(
        ApplicationContext context,
        IValidator<UpdateEmployeeDto> validator,
        ILogger<UpdateEmployeeCommandHandler> logger)
    {
        _context = context;
        _validator = validator;
        _logger = logger;
    }

    public async Task<Result> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating employee {id}", request.Id);

        var employeeToUpdate = await _context
            .Employees
            .FindAsync([request.Id], cancellationToken);

        if (employeeToUpdate is null)
        {
            _logger.LogError("Employee {id} not found", request.Id);
            return Result.Failure(new NotFoundError("Employee not found"));
        }

        var updateEmployeeDto = new UpdateEmployeeDto(
            employeeToUpdate.Surname,
            employeeToUpdate.Name,
            employeeToUpdate.Patronymic,
            employeeToUpdate.Username,
            employeeToUpdate.Role.ToString());

        request.PatchDocument.ApplyTo(updateEmployeeDto);

        await _validator.ValidateAndThrowAsync(updateEmployeeDto);

        employeeToUpdate.Update(updateEmployeeDto);

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Update successful");
            return Result.Success();
        }
        catch (DbUpdateException ex)
            when (ex.InnerException is NpgsqlException { SqlState: PostgresErrorCodes.UniqueViolation })
        {
            _logger.LogError(ex.InnerException, "Username {username} is already taken", employeeToUpdate.Username);
            return Result.Failure(new DbUpdateError("Username is already taken"));
        }
    }
}
