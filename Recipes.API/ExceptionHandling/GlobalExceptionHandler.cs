using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Recipes.API.ExceptionHandling
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(
            exception,
            "Unhandled exception. TraceId: {TraceId}",
            httpContext.TraceIdentifier);

            var (statusCode, source, title, detail) = MapException(exception);

            var problem = new ProblemDetails
            {
                Title = title,
                Status = statusCode,
                Detail = detail
            };

            problem.Extensions["source"] = source;
            problem.Extensions["exceptionType"] = exception.GetType().Name;
            problem.Extensions["traceId"] = httpContext.TraceIdentifier;
            problem.Extensions["path"] = httpContext.Request.Path;

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

            return true;
        }

        private static (int statusCode, string source, string title, string detail)
            MapException(Exception exception)
        {
            return exception switch
            {
                DbUpdateException => (
                    StatusCodes.Status500InternalServerError,
                    "Database",
                    "Database Error",
                    "A database error occurred while processing your request"
                ),

                KeyNotFoundException => (
                    StatusCodes.Status404NotFound,
                    "Code",
                    "Not Found",
                    "The requested resource was not found"
                ),

                ArgumentException => (
                    StatusCodes.Status400BadRequest,
                    "Code",
                    "Bad Request",
                    exception.Message
                ),

                UnauthorizedAccessException => (
                    StatusCodes.Status401Unauthorized,
                    "Code",
                    "Unauthorized",
                    "You are not authorized to perform this action"
                ),

                _ => (
                    StatusCodes.Status500InternalServerError,
                    "Code",
                    "Internal Server Error",
                    "Something went wrong"
                )
            };
        }
    }
}