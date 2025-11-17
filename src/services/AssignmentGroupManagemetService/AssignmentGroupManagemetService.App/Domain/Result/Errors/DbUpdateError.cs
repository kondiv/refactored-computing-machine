namespace AssignmentGroupManagemetService.App.Domain.Result.Errors;

public class DbUpdateError : Error
{
    public DbUpdateError(string message)
        : base(message)
    {
        ErrorCode = ErrorCode.DbUpdate;
    }
}