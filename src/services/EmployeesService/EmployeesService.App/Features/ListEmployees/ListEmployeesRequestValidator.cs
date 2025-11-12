using FluentValidation;

namespace EmployeesService.App.Features.ListEmployees;

internal sealed class ListEmployeesRequestValidator : AbstractValidator<ListEmployeesRequest>
{
    public ListEmployeesRequestValidator()
    {
        RuleFor(r => r.Page)
            .NotNull().WithMessage("Page number is required")
            .GreaterThanOrEqualTo(1).WithMessage("Page must be greater then or equal to 1");

        RuleFor(r => r.MaxPageSize)
            .NotNull().WithMessage("Max page size is required")
            .GreaterThanOrEqualTo(5).WithMessage("Minimal max page size must be at least 5")
            .LessThanOrEqualTo(100).WithMessage("Max page size must not exceed 100");
    }
}
