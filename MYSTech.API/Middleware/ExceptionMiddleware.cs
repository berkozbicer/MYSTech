using MYSTech.API.Models;
using System.Net;
using System.Text.Json;

namespace MYSTech.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Beklenmeyen bir hata oluştu: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = exception switch
            {
                KeyNotFoundException ex => new ExceptionResponse(
                    HttpStatusCode.NotFound,
                    ex.Message),

                UnauthorizedAccessException ex => new ExceptionResponse(
                    HttpStatusCode.Unauthorized,
                    ex.Message),

                ArgumentException ex => new ExceptionResponse(
                    HttpStatusCode.BadRequest,
                    ex.Message),

                InvalidOperationException ex => new ExceptionResponse(
                    HttpStatusCode.BadRequest,
                    ex.Message),

                _ => new ExceptionResponse(
                    HttpStatusCode.InternalServerError,
                    "Sunucu tarafında beklenmeyen bir hata oluştu.")
            };

            context.Response.StatusCode = (int)response.StatusCode;

            var result = ApiResponse<object>.FailResponse(response.Message);
            var json = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(json);
        }
    }

    public record ExceptionResponse(HttpStatusCode StatusCode, string Message);
}
