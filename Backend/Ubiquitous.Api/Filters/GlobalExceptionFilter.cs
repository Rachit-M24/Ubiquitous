using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ubiquitous.Data.Model.DTO.ApiResponseDto;

namespace Ubiquitous.Api.Filters
{
    public sealed class GlobalExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        private readonly IHostEnvironment _environment;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger, IHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            var httpContext = context.HttpContext;
            var exception = context.Exception;

            var statusCode = MapExceptionToStatusCode(exception);
            var messageKey = ResolveMessageKey(exception);

            var traceId = httpContext.TraceIdentifier;
            var requestPath = httpContext.Request.Path.ToString();
            var requestMethod = httpContext.Request.Method;
            var userId = httpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            _logger.LogError(
                exception,
                "Unhandled exception. ExceptionType: {ExceptionType}, StatusCode: {StatusCode}, MessageKey: {MessageKey}, ExceptionMessage: {ExceptionMessage}, RequestPath: {RequestPath}, RequestMethod: {RequestMethod}, TraceId: {TraceId}, UserId: {UserId}",
                exception.GetType().FullName,
                statusCode,
                messageKey,
                exception.Message,
                requestPath,
                requestMethod,
                traceId,
                userId);

            var response = new ApiResponseDto<object?>
            {
                StatusCode = statusCode,
                Message = messageKey,
                Content = _environment.IsDevelopment() ? exception.Message : null
            };

            context.Result = new ObjectResult(response)
            {
                StatusCode = statusCode
            };

            context.ExceptionHandled = true;

            return Task.CompletedTask;
        }

        private static int MapExceptionToStatusCode(Exception exception)
        {
            if (exception is ValidationException)
            {
                return (int)HttpStatusCode.BadRequest;
            }

            if (exception is UnauthorizedAccessException)
            {
                return (int)HttpStatusCode.Forbidden;
            }

            if (exception is KeyNotFoundException)
            {
                return (int)HttpStatusCode.NotFound;
            }

            return (int)HttpStatusCode.InternalServerError;
        }

        private static string ResolveMessageKey(Exception exception)
        {
            if (exception is ValidationException)
            {
                return "Error.ValidationFailed";
            }

            if (exception is UnauthorizedAccessException)
            {
                return "Error.Unauthorized";
            }

            if (exception is KeyNotFoundException)
            {
                return "Error.NotFound";
            }

            return "Error.Unhandled";
        }
    }
}