using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagmentService.App.Features.GetAssignment;
using TaskManagmentService.App.Infrastructure;

namespace TaskManagmentService.App.Features.ListAssignments;

internal sealed class ListAssignmentsRequestHandler : IRequestHandler<ListAssignmentsRequest, IReadOnlyList<GetAssignmentDto>>
{
    private readonly ServiceContext _context;
    private readonly ILogger<ListAssignmentsRequestHandler> _logger;

    public ListAssignmentsRequestHandler(ServiceContext context, ILogger<ListAssignmentsRequestHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IReadOnlyList<GetAssignmentDto>> Handle(ListAssignmentsRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("List assignments.\nPage {page}\nMax page size {maxPageSize}\n" +
            "Project id {projectId}\nEmployee id {employeeId}\nAssignment group id {assignmentGroupId}",
            request.Page, request.MaxPageSize, request.ProjectId, request.EmployeeId, request.AssignmentGroupId);

        var query = _context.Assignments.OrderBy(a => a.Id).AsQueryable();

        if(request.EmployeeId is not null)
        {
            query = query.Where(a => a.AssignmentEmployees
                .Any(ae => ae.EmployeeId == request.EmployeeId));
        }

        if(request.AssignmentGroupId is not null)
        {
            query = query.Where(a => a.AssignmentGroupId == request.AssignmentGroupId);
        }

        if(request.ProjectId is not null)
        {
            query = query.Where(a => a.ProjectId == request.ProjectId);
        }

        var assignments = await query
            .Skip((request.Page - 1) * request.MaxPageSize)
            .Take(request.MaxPageSize)
            .Include(a => a.AssignmentEmployees)
                .ThenInclude(ae => ae.Employee)
            .Select(a => new GetAssignmentDto
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                DeadlineUtc = a.DeadlineUtc,
                CreatedAtUtc = a.CreatedAtUtc,
                Status = a.AssignmentStatus.ToString(),
                Priority = a.Priority.ToString(),
                Executors = a.AssignmentEmployees
                        .Where(ae => ae.AssignmentRole == Domain.Enums.AssignmentRole.Executor)
                        .Select(ae => ae.Employee),
                Observers = a.AssignmentEmployees
                        .Where(ae => ae.AssignmentRole == Domain.Enums.AssignmentRole.Observer)
                        .Select(ae => ae.Employee)
            })
            .AsSplitQuery()
            .ToListAsync(cancellationToken);

        return assignments;
    }
}
