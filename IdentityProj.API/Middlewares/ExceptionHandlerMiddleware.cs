using System.Net;
using System.Security.Authentication;
using IdentityProj.Common.CustomExceptions;
using IdentityProj.Models.Response;
using Newtonsoft.Json;

namespace IdentityProj.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly ILogger _logger;
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(
        RequestDelegate next,
        ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger(nameof(ExceptionHandlerMiddleware));
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NullReferenceException e)
        {
            await HandleExceptionAsync(context, e, HttpStatusCode.InternalServerError);
        }
        catch (FormatException e)
        {
            await HandleExceptionAsync(context, e, HttpStatusCode.InternalServerError);
        }
        catch (InvalidCastException e)
        {
            await HandleExceptionAsync(context, e, HttpStatusCode.BadRequest);
        }
        catch (InvalidOperationException e)
        {
            await HandleExceptionAsync(context, e, HttpStatusCode.BadRequest);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e, HttpStatusCode.InternalServerError);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = JsonConvert.SerializeObject(new
        {
            StatusCode = (int)statusCode,
            Message = exception.Message
        });

        await context.Response.WriteAsync(response);
    }
}