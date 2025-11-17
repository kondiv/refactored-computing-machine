using AssignmentGroupManagemetService.App.Domain.Result;
using MediatR;

namespace AssignmentGroupManagemetService.App.Features.DeleteAssignmentGroup;

internal sealed record DeleteAssignmentGroupCommand(Guid Id) : IRequest<Result>;
