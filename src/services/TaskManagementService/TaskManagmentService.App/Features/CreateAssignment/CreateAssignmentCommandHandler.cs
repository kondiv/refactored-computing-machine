using Contracts.Assignment.Events;
using FluentValidation;
using MassTransit;
using MediatR;
using TaskManagmentService.App.Domain.Entities;
using TaskManagmentService.App.Domain.Enums;
using TaskManagmentService.App.Domain.ValueTypes.Result;
using TaskManagmentService.App.Infrastructure;

namespace TaskManagmentService.App.Features.CreateAssignment;

// TODO: Add validation for project and assingment group existence
internal sealed class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand, Result<CreatedAssignmentDto>>
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ServiceContext _context;
    private readonly IValidator<CreateAssignmentCommand> _validator;
    private readonly ILogger<CreateAssignmentCommandHandler> _logger;

    public CreateAssignmentCommandHandler(
        IPublishEndpoint publishEndpoint,
        ServiceContext context,
        IValidator<CreateAssignmentCommand> validator, 
        ILogger<CreateAssignmentCommandHandler> logger)
    {
        _publishEndpoint = publishEndpoint;
        _context = context;
        _validator = validator;
        _logger = logger;
    }

    public async Task<Result<CreatedAssignmentDto>> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating assingment:\n{title}\n{desc}", request.Title, request.Description);

        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var assingment = new Assignment
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            ProjectId = request.ProjectId,
            AssignmentGroupId = request.AssignmentGroupId,
            DeadlineUtc = request.DeadLineUtc,
            CreatedAtUtc = DateTime.UtcNow,
            AssignmentStatus = Enum.Parse<AssignmentStatus>(request.AssignmentStatus, ignoreCase: true),
            Priority = Enum.Parse<Priority>(request.Priority, ignoreCase: true),
        };

        await _context.Assignments.AddAsync(assingment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        await _publishEndpoint.Publish(
            new AssignmentCreatedEvent(
                assingment.Title,
                assingment.ProjectId,
                assingment.AssignmentGroupId,
                assingment.CreatedAtUtc),
            cancellationToken);

        return Result<CreatedAssignmentDto>.Success(
            new CreatedAssignmentDto
            {
                Id = assingment.Id,
                Title = assingment.Title,
                ProjectId = assingment.ProjectId,
                AssignmentGroupId = assingment.AssignmentGroupId
            });
    }
}
