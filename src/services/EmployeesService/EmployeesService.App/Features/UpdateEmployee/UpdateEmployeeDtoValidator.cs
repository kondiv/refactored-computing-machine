using EmployeesService.App.Domain.Enums;
using FluentValidation;

namespace EmployeesService.App.Features.UpdateEmployee;

// TODO: Implement check for the unique username (make async call to the database)
internal sealed class UpdateEmployeeDtoValidator : AbstractValidator<UpdateEmployeeDto>
{
    
    private static readonly HashSet<string> _validRoles = Enum.GetNames(typeof(Role)).ToHashSet();

    public UpdateEmployeeDtoValidator()
    {
        RuleFor(c => c.Surname)
            .NotEmpty().WithMessage("Surname is required")
            .MinimumLength(2).WithMessage("Surname must be at least 2 characters")
            .MaximumLength(128).WithMessage("Surname must be at most 128 characters")
            .Must(BeValidName).WithMessage("Invalid format");

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(2).WithMessage("Name must be at least 2 characters")
            .MaximumLength(128).WithMessage("Name must be at most 128 characters")
            .Must(BeValidName).WithMessage("Invalid format");

        RuleFor(c => c.Patronymic)
            .NotEmpty().WithMessage("Patronymic is required")
            .MinimumLength(2).WithMessage("Patronymic must be at least 2 characters")
            .MaximumLength(128).WithMessage("Patronymic must be at most 128 characters")
            .Must(BeValidName).WithMessage("Invalid format")
            .Unless(c => string.IsNullOrEmpty(c.Patronymic));

        RuleFor(c => c.Username)
            .NotEmpty().WithMessage("Username is required")
            .MinimumLength(5).WithMessage("Username must be at least 5 characters")
            .MaximumLength(64).WithMessage("Username must be at most 64 characters")
            .Must(NotContaintWhiteSpaces).WithMessage("Invalid format");

        RuleFor(c => c.Role)
            .NotEmpty().WithMessage("Role is required")
            .Must(BeValidRole).WithMessage("Invalid role");
    }

    private static bool BeValidName(string name)
    {
        bool startsWithUpperCaseLetter = char.IsUpper(name[0]);

        bool containsOnlyLetters = name.All(char.IsLetter);

        return startsWithUpperCaseLetter && containsOnlyLetters;
    }

    private static bool NotContaintWhiteSpaces(string username)
    {
        return !username.Any(char.IsWhiteSpace);
    }

    private static bool BeValidRole(string role)
    {
        return _validRoles.Contains(role);
    }
}
