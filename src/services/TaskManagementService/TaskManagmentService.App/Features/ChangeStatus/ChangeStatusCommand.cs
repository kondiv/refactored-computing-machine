using MediatR;
using TaskManagmentService.App.Domain.ValueTypes.Result;

namespace TaskManagmentService.App.Features.ChangeStatus;

internal sealed record ChangeStatusCommand(Guid Id, string Status) : IRequest<Result>;
