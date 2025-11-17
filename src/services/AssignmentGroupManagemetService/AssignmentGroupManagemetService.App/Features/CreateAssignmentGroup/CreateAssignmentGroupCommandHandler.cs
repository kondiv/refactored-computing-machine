using AssignmentGroupManagemetService.App.Domain.Entities;
using AssignmentGroupManagemetService.App.Domain.Result;
using AssignmentGroupManagemetService.App.Infrastructure;
using Contracts.AssignmentGroup;
using MassTransit;
using MediatR;

namespace AssignmentGroupManagemetService.App.Features.CreateAssignmentGroup;

internal sealed class CreateAssignmentGroupCommandHandler : IRequestHandler<CreateAssignmentGroupCommand, Result<CreatedAssignmentGroupDto>>
{
    private readonly ServiceContext _context;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<CreateAssignmentGroupCommandHandler> _logger;

    public CreateAssignmentGroupCommandHandler(
        ServiceContext context,
        IPublishEndpoint publishEndpoint,
        ILogger<CreateAssignmentGroupCommandHandler> logger)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    public async Task<Result<CreatedAssignmentGroupDto>> Handle(CreateAssignmentGroupCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating assignment group {name}", request.Name);
        
        var assignmentGroup = new AssignmentGroup()
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        await _context
            .AssignmentGroups
            .AddAsync(assignmentGroup);

        await _context.SaveChangesAsync();

        var createdAssignmentGroupDto = new CreatedAssignmentGroupDto
        {
            Id = assignmentGroup.Id,
            Name = assignmentGroup.Name,
            CreatedAtUtc = DateTime.UtcNow
        };

        await _publishEndpoint.Publish(new AssignmentGroupCreated(assignmentGroup.Id, DateTime.UtcNow));

        _logger.LogInformation("Assignment group created\n{assignmentGroup}", createdAssignmentGroupDto);

        return Result<CreatedAssignmentGroupDto>.Success(createdAssignmentGroupDto);
    }
}
