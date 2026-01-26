using Microsoft.AspNetCore.Mvc;

namespace GeradorNotaFiscal.exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(httpContext, ex, StatusCodes.Status404NotFound);
            }
            catch (BadRequestException ex)
            {
                await HandleExceptionAsync(httpContext, ex, StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode = StatusCodes.Status500InternalServerError)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            
            var problem = new ProblemDetails
            {
                Status = statusCode,
                Title = exception.Message,
                Instance = context.Request.Path
            };

            return context.Response.WriteAsJsonAsync(problem);
        }
    }
}
