using EmployeesService.App.Domain.ValueTypes.Result;
using MediatR;

namespace EmployeesService.App.Features.GetEmployee;

internal sealed record GetEmployeeRequest(Guid Id) : IRequest<Result<GetEmployeeDto>>;
