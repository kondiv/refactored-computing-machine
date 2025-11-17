using Contracts.Project;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManagementService.App.Domain.ValueTypes.Result;
using ProjectManagementService.App.Domain.ValueTypes.Result.Errors;
using ProjectManagementService.App.Infrastructure;

namespace ProjectManagementService.App.Features.DeleteProject;

internal sealed class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Result>
{
    private readonly ServiceContext _context;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<DeleteProjectCommandHandler> _logger;

    public DeleteProjectCommandHandler(
        ServiceContext context,
        IPublishEndpoint publishEndpoint,
        ILogger<DeleteProjectCommandHandler> logger)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    public async Task<Result> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting project {id}", request.Id);

        bool anyUnfinished = await _context
            .Assignments
            .AnyAsync(a => a.ProjectId == request.Id && a.Status.ToLower() != "canceled", cancellationToken);

        if(anyUnfinished)
        {
            _logger.LogError("There are unfinished assignments in the project {id}", request.Id);
            return Result.Failure(new DbUpdateError("Cannot delete project. Try to cancel or delete assignments first"));
        }

        var affectedRows = await _context
            .Projects
            .Where(p => p.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);

        if(affectedRows != 0)
        {
            await _publishEndpoint.Publish(new ProjectDeleted(request.Id, DateTime.UtcNow));
        }

        return Result.Success();
    }
}
