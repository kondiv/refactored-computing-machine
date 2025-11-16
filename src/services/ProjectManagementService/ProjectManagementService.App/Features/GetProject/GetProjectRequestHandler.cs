using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManagementService.App.Domain.ValueTypes.Result;
using ProjectManagementService.App.Domain.ValueTypes.Result.Errors;
using ProjectManagementService.App.Infrastructure;

namespace ProjectManagementService.App.Features.GetProject;

internal sealed class GetProjectRequestHandler : IRequestHandler<GetProjectRequest, Result<GetProjectDto>>
{
    private readonly ServiceContext _context;
    private readonly ILogger<GetProjectRequestHandler> _logger;

    public GetProjectRequestHandler(ServiceContext context, ILogger<GetProjectRequestHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Result<GetProjectDto>> Handle(GetProjectRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Requesting project {id}", request.Id);

        var project = await _context
            .Projects
            .Where(p => p.Id == request.Id)
            .Include(p => p.Manager)
            .Include(p => p.Supervisor)
            .Select(p => new GetProjectDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Supervisor = p.Supervisor,
                    Manager = p.Manager
                })
            .AsNoTracking()
            .FirstAsync(cancellationToken);

        if(project is null)
        {
            _logger.LogError("Cannot find project with id {id}", request.Id);
            return Result<GetProjectDto>.Failure(new NotFoundError("Project not found"));
        }

        _logger.LogInformation("Project {id} found", request.Id);
        
        return Result<GetProjectDto>.Success(project);
    }
}
