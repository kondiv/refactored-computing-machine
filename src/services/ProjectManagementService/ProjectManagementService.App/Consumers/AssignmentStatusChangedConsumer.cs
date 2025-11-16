using Contracts.Assignment.Events;
using MassTransit;
using ProjectManagementService.App.Infrastructure;

namespace ProjectManagementService.App.Consumers;

internal sealed class AssignmentStatusChangedConsumer : IConsumer<AssignmentStatusChangedEvent>
{
    private readonly ServiceContext _context;
    private readonly ILogger<AssignmentStatusChangedConsumer> _logger;

    public AssignmentStatusChangedConsumer(ServiceContext context, ILogger<AssignmentStatusChangedConsumer> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<AssignmentStatusChangedEvent> context)
    {
        _logger.LogInformation("Assignment {id} status changed. Changing assignment status in Project Management Service",
            context.Message.AssignmentId);

        var assignment = await _context
            .Assignments
            .FindAsync([context.Message.AssignmentId], context.CancellationToken);

        if(assignment is null)
        {
            _logger.LogError("Cannot find assignment with id {id}. Apparently AssignmentCreatedEvent is not proccessed yet ",
                context.Message.AssignmentId);
            return;
        }

        assignment.Status = context.Message.ToStatus;

        await _context.SaveChangesAsync(context.CancellationToken);

        _logger.LogInformation("Assignment {id} status updated successfully", context.Message.AssignmentId);
    }
}
