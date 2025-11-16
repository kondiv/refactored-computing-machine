namespace ProjectManagementService.App.Domain.ValueTypes.Result.Errors;

public enum ErrorCode
{
    SomeError,
    DbUpdate,
    NotFound,
    DbUpdateConcurrency,
    Conflict,
    AlreadyExists,
    AuthProblem,
    Validation,
    CloudStorage
}