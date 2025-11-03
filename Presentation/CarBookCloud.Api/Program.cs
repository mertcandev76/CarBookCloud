using CarBookCloud.Application.Extensions;
using CarBookCloud.Infrastructure.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------
// Connection string
// ---------------------------
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("DefaultConnection yapýlandýrýlmamýþ.");

// ---------------------------
// DI Registration
// Presentation katmaný, hem Infrastructure hem Application'ý register ediyor
builder.Services.AddInfrastructureServices(connectionString); // DbContext, Repositories, UnitOfWork, DomainEventPublisher
builder.Services.AddApplicationServices();                     // MediatR handler’larý

// ---------------------------
// Controllers & Swagger
// ---------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ---------------------------
// Global Exception Handling Middleware
// ---------------------------
app.UseExceptionHandler(config =>
{
    config.Run(async context =>
    {
        context.Response.ContentType = "application/json";
        var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;

        int statusCode = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            ArgumentException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        var response = new
        {
            error = exception?.Message,
            type = exception?.GetType().Name
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    });
});

// ---------------------------
// HTTP PIPELINE
// ---------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// ---------------------------
// Run app
// ---------------------------
await app.RunAsync();
