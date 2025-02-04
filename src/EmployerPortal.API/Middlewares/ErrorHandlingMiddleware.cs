using System.Diagnostics;
using EmployerPortal.Application.Contracts.Responses;
using EmployerPortal.Domain.Errors;

namespace EmployerPortal.API.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    public ErrorHandlingMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlingMiddleware> logger,
        IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "An unhandled exception has occurred");

        var response = context.Response;
        response.ContentType = "application/json";

        var errorResponse = new ErrorResponse
        {
            TraceId = Activity.Current?.Id ?? context.TraceIdentifier
        };

        switch (exception)
        {
            case ValidationError validationEx:
                response.StatusCode = StatusCodes.Status400BadRequest;
                errorResponse.Type = "Validation";
                errorResponse.Message = validationEx.Message;
                errorResponse.Errors = validationEx.Errors;
                break;

            case NotFoundError notFoundEx:
                response.StatusCode = StatusCodes.Status404NotFound;
                errorResponse.Type = "NotFound";
                errorResponse.Message = notFoundEx.Message;
                break;

            default:
                response.StatusCode = StatusCodes.Status500InternalServerError;
                errorResponse.Type = "ServerError";
                errorResponse.Message = _environment.IsDevelopment() 
                    ? exception.Message 
                    : "An internal server error has occurred.";
                break;
        }

        await response.WriteAsJsonAsync(errorResponse);
    }
} 