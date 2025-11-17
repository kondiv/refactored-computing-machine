using Contracts.Assignment.Events;
using Contracts.Project;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using TaskManagmentService.App.Infrastructure;

namespace TaskManagmentService.App.Consumers;

internal sealed class ProjectDeletedConsumer : IConsumer<ProjectDeleted>
{
    private readonly ServiceContext _context;
    private readonly ILogger<ProjectDeletedConsumer> _logger;

    public ProjectDeletedConsumer(ServiceContext context, ILogger<ProjectDeletedConsumer> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<ProjectDeleted> context)
    {
        _logger.LogInformation("Recieved message ProjectDeleted. Deleting project local copy and it's assignments");

        var project = await _context
            .Projects
            .FindAsync(context.Message.Id);

        if (project is null)
        {
            _logger.LogError("ProjectCreated message is not proccessed yet or possible duplicate message recieved");
            return;
        }

        var assignments = await _context
            .Assignments
            .Where(a => a.ProjectId == project.Id)
            .ToListAsync();

        _context
            .Projects
            .Remove(project);

        await _context.SaveChangesAsync();

        var messages = assignments.Select(a => new AssignmentDeletedEvent(
            a.Id,
            a.ProjectId,
            a.AssignmentGroupId,
            DateTime.UtcNow)).ToList();

        await context.PublishBatch(messages);

        _logger.LogInformation("Project local copy deleted. Deleted {n} assignments", assignments.Count);
    }
}
