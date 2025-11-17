using AssignmentGroupManagemetService.App.Domain.Result;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace AssignmentGroupManagemetService.App.Features.UpdateAssignmentGroup;

internal sealed record UpdateAssignmentGroupCommand(Guid Id,
    JsonPatchDocument<UpdateAssignmentGroupDto> PatchDocument) : IRequest<Result>; 
