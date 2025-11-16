using MediatR;
using ProjectManagementService.App.Domain.ValueTypes.Result;

namespace ProjectManagementService.App.Features.DeleteProject;

internal sealed record DeleteProjectCommand(Guid Id) : IRequest<Result>;
