using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using System.Security.Cryptography;

namespace WebApi.Infrastructure.ExceptionHandling
{
    public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(exception.InnerException?.Message);

            switch (exception)
            {
                case NotImplementedException _:
                    httpContext.Response.StatusCode = StatusCodes.Status501NotImplemented;
                    break;

                case NotSupportedException _:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;

                case InvalidOperationException _:
                case DbUpdateConcurrencyException _:
                case CryptographicException _:
                case DbUpdateException _:
                    httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                    break;

                default:
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            var problemDetails = new ProblemDetails
            {
                Title = "An exception occurred!!",
                Status = httpContext.Response.StatusCode,
                Detail = exception.InnerException?.Message,
                Instance = exception.HelpLink
            };

            await httpContext.Response.WriteAsJsonAsync(value: problemDetails, options: null, contentType: MediaTypeNames.Application.ProblemJson, cancellationToken);
            return true;
        }
    }
}
