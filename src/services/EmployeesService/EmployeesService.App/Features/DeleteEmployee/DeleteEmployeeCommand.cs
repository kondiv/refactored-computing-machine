using EmployeesService.App.Domain.ValueTypes.Result;
using MediatR;

namespace EmployeesService.App.Features.DeleteEmployee;

internal record DeleteEmployeeCommand(Guid Id) : IRequest<Result>;
