using AssignmentGroupManagemetService.App.Domain.Result;
using AssignmentGroupManagemetService.App.Domain.Result.Errors;
using AssignmentGroupManagemetService.App.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AssignmentGroupManagemetService.App.Features.GetAssignmentGroup;

internal sealed class GetAssignmentGroupRequestHandler : IRequestHandler<GetAssignmentGroupRequest, Result<GetAssignmentGroupDto>>
{
    private readonly ServiceContext _context;
    private readonly ILogger<GetAssignmentGroupRequestHandler> _logger;

    public GetAssignmentGroupRequestHandler(ServiceContext context, ILogger<GetAssignmentGroupRequestHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Result<GetAssignmentGroupDto>> Handle(GetAssignmentGroupRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Requesting assignment group {id}", request.Id);

        var assignmentGroup = await _context
            .AssignmentGroups
            .Where(a => a.Id == request.Id)
            .Select(a => new GetAssignmentGroupDto
            {
                Id = a.Id,
                Name = a.Name
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (assignmentGroup is null)
        {
            _logger.LogError("Cannot find assignment group with id {id}", request.Id);
            return Result<GetAssignmentGroupDto>.Failure(new NotFoundError("Assignment group not found"));
        }

        _logger.LogInformation("Assignment group found {assignmentGroup}", assignmentGroup);
        return Result<GetAssignmentGroupDto>.Success(assignmentGroup);
    }
}
