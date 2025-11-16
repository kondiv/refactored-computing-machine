using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManagementService.App.Features.GetProject;
using ProjectManagementService.App.Infrastructure;

namespace ProjectManagementService.App.Features.ListProjects;

internal sealed class ListProjectsRequestHandler : IRequestHandler<ListProjectsRequest, IReadOnlyList<GetProjectDto>>
{
    private readonly ServiceContext _context;
    private readonly ILogger<ListProjectsRequestHandler> _logger;

    public ListProjectsRequestHandler(ServiceContext context, ILogger<ListProjectsRequestHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IReadOnlyList<GetProjectDto>> Handle(ListProjectsRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Reuqestins list of projects.\nPage {page}\nMax page size {maxPageSize}",
            request.Page, request.MaxPageSize);

        var projects = await _context
            .Projects
            .OrderBy(p => p.Id)
            .Include(p => p.Manager)
            .Include(p => p.Supervisor)
            .Select(p => new GetProjectDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Supervisor = p.Supervisor,
                    Manager = p.Manager
                })
            .Skip((request.Page - 1) * request.MaxPageSize)
            .Take(request.MaxPageSize)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return projects;
    }
}
