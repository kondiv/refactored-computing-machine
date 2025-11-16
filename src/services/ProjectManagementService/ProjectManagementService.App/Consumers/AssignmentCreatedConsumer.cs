using Contracts.Assignment.Events;
using MassTransit;
using ProjectManagementService.App.Domain.Entities;
using ProjectManagementService.App.Infrastructure;

namespace ProjectManagementService.App.Consumers;

internal sealed class AssignmentCreatedConsumer : IConsumer<AssignmentCreatedEvent>
{
    private readonly ServiceContext _context;
    private readonly ILogger<AssignmentCreatedConsumer> _logger;

    public AssignmentCreatedConsumer(ServiceContext context, ILogger<AssignmentCreatedConsumer> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<AssignmentCreatedEvent> context)
    {
        _logger.LogInformation("New assignment created for project {id}", context.Message.ProjectId);

        var assignment = new Assignment
        {
            Id = context.Message.AssignmentId,
            ProjectId = context.Message.ProjectId,
            Status = context.Message.Status
        };

        await _context.Assignments.AddAsync(assignment, context.CancellationToken);
        await _context.SaveChangesAsync(context.CancellationToken);

        _logger.LogInformation("New assignment created {assignment}", assignment);
    }
}
