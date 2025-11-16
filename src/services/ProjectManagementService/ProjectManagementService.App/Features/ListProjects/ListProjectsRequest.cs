using MediatR;
using ProjectManagementService.App.Features.GetProject;

namespace ProjectManagementService.App.Features.ListProjects;

internal sealed record ListProjectsRequest(int Page, int MaxPageSize) : IRequest<IReadOnlyList<GetProjectDto>>;
