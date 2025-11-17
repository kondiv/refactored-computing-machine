using AssignmentGroupManagemetService.App.Features.GetAssignmentGroup;
using AssignmentGroupManagemetService.App.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AssignmentGroupManagemetService.App.Features.ListAssignmentGroups;

internal sealed class ListAssignmentGroupsRequestHandler
    : IRequestHandler<ListAssignmentGroupsRequest, IReadOnlyList<GetAssignmentGroupDto>>
{
    private readonly ServiceContext _context;
    private readonly ILogger<ListAssignmentGroupsRequestHandler> _logger;

    public ListAssignmentGroupsRequestHandler(ServiceContext context, ILogger<ListAssignmentGroupsRequestHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IReadOnlyList<GetAssignmentGroupDto>> Handle(ListAssignmentGroupsRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Requesting list of assignment groups\nPage {page}\nMax page size {maxPageSize}",
            request.Page, request.MaxPageSize);

        var assignmentGroups = await _context
            .AssignmentGroups
            .OrderBy(ag => ag.Id)
            .Select(ag => new GetAssignmentGroupDto
            {
                Id = ag.Id,
                Name = ag.Name
            })
            .Skip((request.Page - 1) * request.MaxPageSize)
            .Take(request.MaxPageSize)
            .ToListAsync(cancellationToken);

        return assignmentGroups;
    }
}
