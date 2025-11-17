using AssignmentGroupManagemetService.App.Infrastructure;
using Contracts.Assignment.Events;
using MassTransit;

namespace AssignmentGroupManagemetService.App.Consumers;

internal sealed class AssignmentDeletedConsumer : IConsumer<AssignmentDeletedEvent>
{
    private readonly ServiceContext _context;
    private readonly ILogger<AssignmentDeletedConsumer> _logger;

    public AssignmentDeletedConsumer(ServiceContext context, ILogger<AssignmentDeletedConsumer> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<AssignmentDeletedEvent> context)
    {
        _logger.LogInformation("Assignment {id} deleted. Deleting assignment for Project Management Service",
            context.Message.AssignmentId);

        var assignment = await _context
            .Assignments
            .FindAsync([context.Message.AssignmentId], context.CancellationToken);

        if(assignment is null)
        {
            _logger.LogError("Cannot find assignment with id {id}. AssignmentCreatedEvent is not proccessed yet " +
                "or duplicate AssignmentDeletedEvent recieved", context.Message.AssignmentId);
            return;
        }

        _context.Assignments.Remove(assignment);

        await _context.SaveChangesAsync(context.CancellationToken);

        _logger.LogInformation("Assignment {id} deleted successfully", context.Message.AssignmentId);
    }
}
