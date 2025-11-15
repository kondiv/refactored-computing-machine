namespace TaskManagmentService.App.Domain.ValueTypes.Result.Errors;

public class DbUpdateConcurrencyError : Error
{
    public DbUpdateConcurrencyError(string message) 
        : base(message)
    {
        ErrorCode = ErrorCode.DbUpdateConcurrency;
    }
}