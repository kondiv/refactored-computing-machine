using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace TaskManagmentService.App.Exceptions;

internal sealed class ValidationExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;
    private readonly ILogger<ValidationExceptionHandler> _logger;

    public ValidationExceptionHandler(
        IProblemDetailsService problemDetailsService,
        ILogger<ValidationExceptionHandler> logger)
    {
        _problemDetailsService = problemDetailsService;
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
        {
            return false;
        }

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        var context = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
            {
                Detail = "One or more validation errors occurred",
                Status = StatusCodes.Status400BadRequest,
            }
        };

        var errors = validationException.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key.ToLowerInvariant(),
                g => g.Select(e => e.ErrorMessage).ToArray()
            );
        context.ProblemDetails.Extensions.Add("errors", errors);

        return await _problemDetailsService.TryWriteAsync(context);
    }
}
