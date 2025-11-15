using MediatR;
using TaskManagmentService.App.Domain.ValueTypes.Result;

namespace TaskManagmentService.App.Features.AddAssignmentExecutor;

internal sealed record AddAssignmentExecutorCommand(Guid AssignmentId, Guid EmployeeId) : IRequest<Result>;
