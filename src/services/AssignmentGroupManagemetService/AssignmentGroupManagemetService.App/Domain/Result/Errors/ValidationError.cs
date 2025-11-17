namespace AssignmentGroupManagemetService.App.Domain.Result.Errors;

public class ValidationError : Error
{
    public ValidationError(string message)
        : base(message)
    {
        ErrorCode = ErrorCode.Validation;
    }
}