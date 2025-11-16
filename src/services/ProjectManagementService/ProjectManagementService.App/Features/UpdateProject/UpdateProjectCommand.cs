using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using ProjectManagementService.App.Domain.ValueTypes.Result;

namespace ProjectManagementService.App.Features.UpdateProject;

internal sealed record UpdateProjectCommand(Guid Id, JsonPatchDocument<UpdateProjectDto> PatchDocument)
    : IRequest<Result>;
