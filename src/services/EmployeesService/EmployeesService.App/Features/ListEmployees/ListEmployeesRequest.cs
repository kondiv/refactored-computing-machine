using EmployeesService.App.Features.GetEmployee;
using MediatR;

namespace EmployeesService.App.Features.ListEmployees;

internal sealed record ListEmployeesRequest(int Page, int MaxPageSize) : IRequest<IReadOnlyList<GetEmployeeDto>>;

