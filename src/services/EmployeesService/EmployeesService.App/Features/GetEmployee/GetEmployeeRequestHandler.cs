using EmployeesService.App.Domain.ValueTypes.Result;
using EmployeesService.App.Domain.ValueTypes.Result.Errors;
using EmployeesService.App.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace EmployeesService.App.Features.GetEmployee;

internal sealed class GetEmployeeRequestHandler : IRequestHandler<GetEmployeeRequest, Result<GetEmployeeDto>>
{
    private readonly ApplicationContext _context;
    private readonly ILogger<GetEmployeeRequestHandler> _logger;

    public GetEmployeeRequestHandler(ApplicationContext context, ILogger<GetEmployeeRequestHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Result<GetEmployeeDto>> Handle(GetEmployeeRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Requesting employee with id {id}", request.Id);

        var employeeDto = await _context
           .Employees
           .Where(e => e.Id == request.Id)
           .Select(e => new GetEmployeeDto
                {
                    Id = e.Id,
                    Surname = e.Surname,
                    Name = e.Name,
                    Patronymic = e.Patronymic,
                    Username =e.Username,
                    Role = e.Role.ToString()
                })
           .AsNoTracking()
           .FirstOrDefaultAsync(cancellationToken);

        if(employeeDto is null)
        {
            _logger.LogError("Employee {id} not found", request.Id);
            return Result<GetEmployeeDto>.Failure(new NotFoundError("Employee not found"));
        }

        _logger.LogInformation("Employee found");
        return Result<GetEmployeeDto>.Success(employeeDto);
    }
}
