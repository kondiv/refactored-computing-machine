namespace TaskManagmentService.App.Domain.ValueTypes.Result.Errors;

public class ValidationError : Error
{
    public ValidationError(string message)
        : base(message)
    {
        ErrorCode = ErrorCode.Validation;
    }
}