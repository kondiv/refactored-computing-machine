using Contracts.Assignment.Events;
using Contracts.AssignmentGroup;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using TaskManagmentService.App.Infrastructure;

namespace TaskManagmentService.App.Consumers;

internal sealed class AssignmentGroupDeletedConsumer : IConsumer<AssignmentGroupDeleted>
{
    private readonly ServiceContext _context;
    private readonly ILogger<AssignmentGroupDeletedConsumer> _logger;

    public AssignmentGroupDeletedConsumer(ServiceContext context, ILogger<AssignmentGroupDeletedConsumer> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<AssignmentGroupDeleted> context)
    {
        _logger.LogInformation("AssignmentGroupDeleted message recieved. Deleting local copy and it's assignments");

        var assignmentGroup = await _context
            .AssignmentGroups
            .FindAsync(context.Message.Id);

        if (assignmentGroup == null)
        {
            _logger.LogError("Apparently AssignmentGroupCreated message is not proccessed yet");
            return;
        }

        var assignments = await _context
            .Assignments
            .Where(a => a.AssignmentGroupId == assignmentGroup.Id)
            .ToListAsync();

        _context
            .AssignmentGroups
            .Remove(assignmentGroup);

        await _context.SaveChangesAsync();

        var messages = assignments.Select(a => new AssignmentDeletedEvent(
            a.Id,
            a.ProjectId,
            a.AssignmentGroupId,
            DateTime.UtcNow))
            .ToList();

        await context.PublishBatch(messages);

        _logger.LogInformation("Local copy succesfully deleted. Deleted {n} assignments", assignments.Count);
    }
}
