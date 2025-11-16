using MediatR;
using ProjectManagementService.App.Domain.ValueTypes.Result;

namespace ProjectManagementService.App.Features.CreateProject;

internal sealed record CreateProjectCommand(string Name, string Description, Guid SupervisorId, Guid ManagerId)
    : IRequest<Result<CreatedProjectDto>>;