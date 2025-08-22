using System.Reflection.Metadata;
using EmployeeManagement.Api.Models;

namespace EmployeeManagement.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
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

        public async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var statusCode = ex switch
            {
                ArgumentNullException => StatusCodes.Status400BadRequest,  
                KeyNotFoundException => StatusCodes.Status404NotFound,     
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,  
                _ => StatusCodes.Status500InternalServerError              
            };

            var errorResponse = new ErrorDetail
            {
                StatusCode = statusCode,
                Message = statusCode switch
                {
                    StatusCodes.Status400BadRequest => "Bad Request",
                    StatusCodes.Status404NotFound => "Resource Not Found",
                    StatusCodes.Status401Unauthorized => "Unauthorized Access",
                    _ => "Internal Server Error"
                },
                Details = $"Error: {ex.Message}"
            };
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(errorResponse));
        }
    }
}