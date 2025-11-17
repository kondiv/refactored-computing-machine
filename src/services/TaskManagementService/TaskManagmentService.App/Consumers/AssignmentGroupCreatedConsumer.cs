using Contracts.AssignmentGroup;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using TaskManagmentService.App.Domain.Entities;
using TaskManagmentService.App.Infrastructure;

namespace TaskManagmentService.App.Consumers;

internal sealed class AssignmentGroupCreatedConsumer : IConsumer<AssignmentGroupCreated>
{
    private readonly ServiceContext _context;
    private readonly ILogger<AssignmentGroupCreatedConsumer> _logger;

    public AssignmentGroupCreatedConsumer(ServiceContext context, ILogger<AssignmentGroupCreatedConsumer> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<AssignmentGroupCreated> context)
    {
        _logger.LogInformation("AssignmentGroupCreated message recieved. Creating local copy of assignment group");

        var assignmentGroup = new AssignmentGroup
        {
            Id = context.Message.Id
        };

        await _context
            .AssignmentGroups
            .AddAsync(assignmentGroup);

        try
        {
            await _context.SaveChangesAsync();
            _logger.LogInformation("Assignment group copy created successfully");
        }
        catch (DbUpdateException ex)
            when (ex.InnerException is NpgsqlException { SqlState: PostgresErrorCodes.UniqueViolation })
        {
            _logger.LogError("Assignment group {id} already exists. Possible AssignmentGroupCreated message duplicate recieved",
                assignmentGroup.Id);
        }
    }
}
