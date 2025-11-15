using MediatR;
using TaskManagmentService.App.Domain.ValueTypes.Result;

namespace TaskManagmentService.App.Features.AddAssignmentObserver;

internal sealed record AddAssignmentObserverCommand(Guid AssignmentId, Guid EmployeeId) : IRequest<Result>;

