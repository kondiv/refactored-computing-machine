using FluentValidation;
using TaskManagmentService.App.Domain.Enums;

namespace TaskManagmentService.App.Features.CreateAssignment;

internal sealed class CreateAssignmentCommandValidator : AbstractValidator<CreateAssignmentCommand>
{
    public CreateAssignmentCommandValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty().WithMessage("Title is required")
            .MinimumLength(2).WithMessage("Title must be at least 2 characters")
            .MaximumLength(128).WithMessage("Title must be at most 128 characters");

        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Description is required")
            .MinimumLength(2).WithMessage("Description must be at least 2 characters")
            .MaximumLength(512).WithMessage("Description must be at most 512 characters");

        RuleFor(c => c.ProjectId)
            .NotNull().WithMessage("Project id is required");

        RuleFor(c => c.AssignmentGroupId)
            .NotNull().WithMessage("Assignment group id is required");

        RuleFor(c => c.DeadLineUtc)
            .NotNull().WithMessage("Deadline is required")
            .GreaterThan(DateTime.UtcNow).WithMessage("Deadline cannot be at past");

        RuleFor(c => c.AssignmentStatus)
            .NotEmpty().WithMessage("Assignment status is required")
            .Must(s => string.Equals(s, "backlog", StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(s, "current", StringComparison.OrdinalIgnoreCase))
            .WithMessage("Assigment status must be \"Backlog\" or \"Current\"");

        RuleFor(c => c.Priority)
            .NotEmpty().WithMessage("Priopirty is required")
            .IsEnumName(typeof(Priority), caseSensitive: false).WithMessage("Must be a valid priority");
    }
}
