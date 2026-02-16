using System.Text.Json;
using UserManagement.Exceptions;
using UserManagement.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserManagement.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public GlobalExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionHandlerMiddleware> logger,
            IWebHostEnvironment env
            )
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Determiner le type d'erreur et le code HTTP
            var (statusCode, message, details, validationErrors) = GetErrorDetails(exception);

            // Creer la reponse d'erreur
            var errorResponse = new ErrorResponse(statusCode, message, details)
            {
                ValidationErrors = validationErrors,
                // StackTrace seulement en developpement
                StackTrace = _env.IsDevelopment() ? exception.ToString() : null
            };

            // Configurer la reponse HTTP
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            // Ecrire la reponse 
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            }));
        }

        private static (int statusCode, string message, string? details, Dictionary<string, List<string>>? validationErrors)
            GetErrorDetails(Exception exception)
        {
            return exception switch
            {
                // Exceptions personnalisées
                ValidationException validationEx => (400, "Validation failed", null, validationEx.ValidationErrors),
                NotFoundException notFoundEx => (404, notFoundEx.Message, notFoundEx.Details, null),
                BadRequestException badRequestEx => (400, badRequestEx.Message, badRequestEx.Details, null),
                ForbiddenException forbiddenEx => (403, forbiddenEx.Message, forbiddenEx.Details, null),
                ApiException apiEx => (apiEx.StatusCode, apiEx.Message, apiEx.Details, null),

                // Exceptions .NET courantes
                KeyNotFoundException => (404, "Resource not found", "The requested resource could not be found", null),
                ArgumentException argEx => (400, "Bad request", argEx.Message, null),
                InvalidOperationException invalidOpEx => (400, "Invalid operation", invalidOpEx.Message, null),

                // Exceptions de base de données EF Core
                Microsoft.EntityFrameworkCore.DbUpdateException dbEx => (500, "Database error", "A database error occurred while processing your request", null),

                // Erreur inattendue(500)
                _ => (500, "Internal server error", "An unexpected error occurred. Please try again later.", null)
            };
        }

    }
}
