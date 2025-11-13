using EmployeesService.App.Features.GetEmployee;
using EmployeesService.App.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesService.App.Features.ListEmployees;

internal sealed class ListEmployeesRequestHandler : IRequestHandler<ListEmployeesRequest, IReadOnlyList<GetEmployeeDto>>
{
    private readonly ApplicationContext _context;
    private readonly IValidator<ListEmployeesRequest> _validator;
    private readonly ILogger<ListEmployeesRequestHandler> _logger;

    public ListEmployeesRequestHandler(
        ApplicationContext context,
        IValidator<ListEmployeesRequest> validator,
        ILogger<ListEmployeesRequestHandler> logger)
    {
        _context = context;
        _validator = validator;
        _logger = logger;
    }

    public async Task<IReadOnlyList<GetEmployeeDto>> Handle(ListEmployeesRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Requesting list of employees. Page: {page}. MaxPageSize: {maxPageSize}",
            request.Page, request.MaxPageSize);
        
        _validator.ValidateAndThrow(request);

        IReadOnlyList<GetEmployeeDto> employees = await _context
            .Employees
            .Select(e => new GetEmployeeDto
                {
                    Id = e.Id,
                    Surname = e.Surname,
                    Name = e.Name,
                    Patronymic = e.Patronymic,
                    Username = e.Username,
                    Role = e.Role.ToString()
                })
            .OrderBy(e => e.Id)
            .Skip((request.Page - 1) * request.MaxPageSize)
            .Take(request.MaxPageSize)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return employees;
    }
}
