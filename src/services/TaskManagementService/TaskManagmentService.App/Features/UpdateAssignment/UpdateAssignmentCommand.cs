using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using TaskManagmentService.App.Domain.ValueTypes.Result;

namespace TaskManagmentService.App.Features.UpdateAssignment;

internal sealed record UpdateAssignmentCommand(Guid Id, JsonPatchDocument<UpdateAssignmentDto> PatchDocument)
    : IRequest<Result>;
