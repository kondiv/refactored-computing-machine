using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManagementService.App.Domain.Entities;
using ProjectManagementService.App.Domain.ValueTypes.Result;
using ProjectManagementService.App.Domain.ValueTypes.Result.Errors;
using ProjectManagementService.App.Infrastructure;

namespace ProjectManagementService.App.Features.CreateProject;

internal sealed class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Result<CreatedProjectDto>>
{
    private readonly ServiceContext _context;
    private readonly ILogger<CreateProjectCommandHandler> _logger;

    public CreateProjectCommandHandler(ServiceContext context, ILogger<CreateProjectCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Result<CreatedProjectDto>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new project {name}", request.Name);

        bool supervisorExists = await _context
            .Employees
            .AnyAsync(e => e.Id == request.SupervisorId, cancellationToken);

        if (!supervisorExists)
        {
            _logger.LogError("Cannot find employee with id {id} to set as supervisor", request.SupervisorId);
            return Result<CreatedProjectDto>.Failure(new NotFoundError("Supervisor not found"));
        }

        var managerExists = request.SupervisorId == request.ManagerId
            || await _context.Employees.AnyAsync(e => e.Id == request.ManagerId, cancellationToken);

        if (!managerExists)
        {
            _logger.LogError("Cannot find employee with id {id} to set as manager", request.ManagerId);
            return Result<CreatedProjectDto>.Failure(new NotFoundError("Manager not found"));
        }

        var project = new Project
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            SupervisorId = request.SupervisorId,
            ManagerId = request.ManagerId
        };

        await _context
            .Projects
            .AddAsync(project, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<CreatedProjectDto>.Success(new CreatedProjectDto(
            project.Id,
            project.Name,
            DateTime.UtcNow));
    }
}