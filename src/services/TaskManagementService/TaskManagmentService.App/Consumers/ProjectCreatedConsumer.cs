using Contracts.Project;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using TaskManagmentService.App.Domain.Entities;
using TaskManagmentService.App.Infrastructure;

namespace TaskManagmentService.App.Consumers;

internal sealed class ProjectCreatedConsumer : IConsumer<ProjectCreated>
{
    private readonly ServiceContext _context;
    private readonly ILogger<ProjectCreatedConsumer> _logger;

    public ProjectCreatedConsumer(ServiceContext context, ILogger<ProjectCreatedConsumer> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<ProjectCreated> context)
    {
        _logger.LogInformation("Recieved message ProjectCreated. Creating local copy");

        var project = new Project
        {
            Id = context.Message.Id
        };

        await _context
            .Projects
            .AddAsync(project);

        try
        {
            await _context.SaveChangesAsync();
            _logger.LogInformation("Project local copy created successfully");
        }

        catch (DbUpdateException ex)
            when (ex.InnerException is NpgsqlException { SqlState: PostgresErrorCodes.UniqueViolation })
        {
            _logger.LogError("Possible duplicate ProjectCreated message recieved");
        }
    }
}
