using MediatR;
using ProjectManagementService.App.Domain.ValueTypes.Result;
using ProjectManagementService.App.Domain.ValueTypes.Result.Errors;
using ProjectManagementService.App.Infrastructure;

namespace ProjectManagementService.App.Features.UpdateProject;

internal sealed class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Result>
{
    private readonly ServiceContext _context;
    private readonly ILogger<UpdateProjectCommandHandler> _logger;

    public UpdateProjectCommandHandler(ServiceContext context, ILogger<UpdateProjectCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Result> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating info for project {id}", request.Id);

        var project = await _context
           .Projects
           .FindAsync([request.Id], cancellationToken);

        if (project is null)
        {
            _logger.LogError("Cannot find project with id {id}", request.Id);
            return Result.Failure(new NotFoundError("Project not found"));
        }

        var updateProjectDto = new UpdateProjectDto(project.Name, project.Description);

        request.PatchDocument.ApplyTo(updateProjectDto);

        project.Name = updateProjectDto.Name;
        project.Description = updateProjectDto.Description;

        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Project {id} updated successfully", request.Id);
        return Result.Success();
    }
}
