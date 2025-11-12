namespace EmployeesService.App.Domain.ValueTypes.Result.Errors;

public class AuthError : Error
{
    public AuthError(string message)
        : base(message)
    {
        ErrorCode = ErrorCode.AuthProblem;
    }
}