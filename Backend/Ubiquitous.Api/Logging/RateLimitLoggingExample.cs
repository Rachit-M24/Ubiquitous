using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ubiquitous.Api
{
    public static class RateLimitLoggingExtensions
    {
        public static IServiceCollection AddRateLimitingWithLogging(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                {
                    var userId = httpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    var key = userId ?? httpContext.Connection.RemoteIpAddress?.ToString() ?? "anonymous";

                    return RateLimitPartition.GetFixedWindowLimiter(
                        key,
                        _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 100,
                            Window = TimeSpan.FromMinutes(1),
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            QueueLimit = 0
                        });
                });

                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                options.OnRejected = (context, token) =>
                {
                    var httpContext = context.HttpContext;
                    var loggerFactory = httpContext.RequestServices.GetRequiredService<ILoggerFactory>();
                    var logger = loggerFactory.CreateLogger("RateLimiting");

                    var userId = httpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    var ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();
                    var endpointName = httpContext.GetEndpoint()?.DisplayName;
                    var traceId = httpContext.TraceIdentifier;

                    var policyName = context.Lease.TryGetMetadata(MetadataName.Create<string>("LimiterName"), out var limiterName)
                        ? limiterName
                        : "Global";

                    logger.LogWarning(
                        "Rate limit exceeded. Policy: {PolicyName}, Endpoint: {EndpointName}, UserId: {UserId}, IpAddress: {IpAddress}, TraceId: {TraceId}",
                        policyName,
                        endpointName,
                        userId,
                        ipAddress,
                        traceId);

                    return ValueTask.CompletedTask;
                };
            });

            return services;
        }
    }
}