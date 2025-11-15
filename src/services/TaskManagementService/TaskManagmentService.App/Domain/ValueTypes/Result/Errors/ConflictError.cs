namespace TaskManagmentService.App.Domain.ValueTypes.Result.Errors;

public class ConflictError : Error
{
    public ConflictError(string message)
        : base(message)
    {
        ErrorCode = ErrorCode.Conflict;
    }
}