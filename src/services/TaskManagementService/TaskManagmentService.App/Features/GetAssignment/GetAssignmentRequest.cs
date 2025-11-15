using MediatR;
using TaskManagmentService.App.Domain.ValueTypes.Result;

namespace TaskManagmentService.App.Features.GetAssignment;

internal sealed record GetAssignmentRequest(Guid Id) : IRequest<Result<GetAssignmentDto>>;
