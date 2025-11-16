using MediatR;
using ProjectManagementService.App.Domain.ValueTypes.Result;

namespace ProjectManagementService.App.Features.GetProject;

internal sealed record GetProjectRequest(Guid Id) : IRequest<Result<GetProjectDto>>;