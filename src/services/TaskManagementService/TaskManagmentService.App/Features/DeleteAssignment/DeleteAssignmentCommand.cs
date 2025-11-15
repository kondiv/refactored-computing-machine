using MediatR;
using TaskManagmentService.App.Domain.ValueTypes.Result;

namespace TaskManagmentService.App.Features.DeleteAssignment;

internal sealed record DeleteAssignmentCommand(Guid Id) : IRequest<Result>;
