using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Ubiquitous.Api;
using Ubiquitous.Api.Filters;
using Ubiquitous.Service.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole(options => options.IncludeScopes = true);
builder.Logging.AddDebug();
builder.Logging.SetMinimumLevel(LogLevel.Information);

if (builder.Environment.IsDevelopment())
{
    builder.Logging.AddFilter("Microsoft", LogLevel.Information);
    builder.Logging.AddFilter("System", LogLevel.Information);
}
else
{
    builder.Logging.AddFilter("Microsoft", LogLevel.Warning);
    builder.Logging.AddFilter("System", LogLevel.Warning);
}

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddDbContext<UbiquitousDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<GlobalExceptionFilter>();
builder.Services.AddTransient<PaginationExampleService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "URL Manager API",
        Version = "v1"
    });
});

builder.Services.AddRateLimitingWithLogging();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "URL Manager v1");
    });
}

app.UseHttpsRedirection();

app.UseRateLimiter();

app.Use(async (context, next) =>
{
    var loggerFactory = context.RequestServices.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger("RequestScope");

    var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    using (logger.BeginScope(new Dictionary<string, object?>
    {
        ["UserId"] = string.IsNullOrEmpty(userId) ? "anonymous" : userId,
        ["RequestId"] = context.TraceIdentifier
    }))
    {
        await next();
    }
});

// app.UseAuthentication(); // enable when identity is wired
app.UseAuthorization();

app.MapControllers();

app.Run();