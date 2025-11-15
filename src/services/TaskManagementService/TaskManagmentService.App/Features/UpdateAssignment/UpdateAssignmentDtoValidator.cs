using FluentValidation;
using TaskManagmentService.App.Domain.Enums;

namespace TaskManagmentService.App.Features.UpdateAssignment;

internal sealed class UpdateAssignmentDtoValidator : AbstractValidator<UpdateAssignmentDto>
{
    public UpdateAssignmentDtoValidator()
    {
        RuleFor(d => d.Title)
            .NotEmpty().WithMessage("Title is required")
            .MinimumLength(2).WithMessage("Title must be at least 2 characters")
            .MaximumLength(128).WithMessage("Title must be at most 128 characters");

        RuleFor(d => d.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(512).WithMessage("Description must be at most 512 characters");

        RuleFor(d => d.Priority)
            .NotEmpty().WithMessage("Priority is required")
            .IsEnumName(typeof(Priority), caseSensitive: false).WithMessage("Must be a valid priority");
    }
}
