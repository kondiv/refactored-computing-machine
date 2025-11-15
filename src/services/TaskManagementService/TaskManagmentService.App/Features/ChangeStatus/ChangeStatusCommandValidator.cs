using FluentValidation;
using TaskManagmentService.App.Domain.Enums;

namespace TaskManagmentService.App.Features.ChangeStatus;

internal sealed class ChangeStatusCommandValidator : AbstractValidator<ChangeStatusCommand>
{
    public ChangeStatusCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id is required");

        RuleFor(c => c.Status)
            .NotEmpty().WithMessage("Status is required")
            .IsEnumName(typeof(AssignmentStatus), caseSensitive: false).WithName("Must be a valid status");
    }
}
