using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Taller.Middlewares
{
    public class ErrorHandler : Controller
    {
        private readonly RequestDelegate _next;

        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ValidationException ex)
            {
                Response(httpContext, ex.Errors.Select(x => x.ErrorMessage).ToList());
            }
            catch (Exception ex)
            {
                Response(httpContext, new List<string>() { ex.Message }, ex);
            }
        }

        public new void Response(HttpContext context, IReadOnlyCollection<string> errors = null, Exception ex = null)
        {
            var body = JsonSerializer.Serialize(new
            {
                errors,
                ex = (ex == null ? null : new { ex.Message, ex.StackTrace, ex.Source })
            });
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "text/json";
            context.Response.WriteAsync(body);
        }
    }

    public static class ErrorHandlerExtensions
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandler>();
        }
    }
}
