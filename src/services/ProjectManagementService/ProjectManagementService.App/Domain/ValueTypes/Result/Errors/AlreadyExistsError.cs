namespace ProjectManagementService.App.Domain.ValueTypes.Result.Errors;

public class AlreadyExistsError : Error
{
    public AlreadyExistsError(string message)
        : base(message)
    {
        ErrorCode = ErrorCode.AlreadyExists;
    }
}