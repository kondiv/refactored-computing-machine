using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagmentService.App.Domain.ValueTypes.Result;
using TaskManagmentService.App.Domain.ValueTypes.Result.Errors;
using TaskManagmentService.App.Infrastructure;

namespace TaskManagmentService.App.Features.GetAssignment;

internal sealed class GetAssignmentRequestHandler : IRequestHandler<GetAssignmentRequest, Result<GetAssignmentDto>>
{
    private readonly ServiceContext _context;
    private readonly ILogger<GetAssignmentRequestHandler> _logger;

    public GetAssignmentRequestHandler(ServiceContext context, ILogger<GetAssignmentRequestHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Result<GetAssignmentDto>> Handle(GetAssignmentRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Requesting for assignment {id}", request.Id);

        var assignment = await _context
            .Assignments
            .Where(a => a.Id == request.Id)
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
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (assignment is null)
        {
            _logger.LogError("Cannot find assignment with id: {id}", request.Id);
            return Result<GetAssignmentDto>.Failure(new NotFoundError("Assignment not found"));
        }

        _logger.LogInformation("Found assignment {id}", request.Id);
        return Result<GetAssignmentDto>.Success(assignment);
    }
}
