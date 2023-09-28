using System.Net;
using Newtonsoft.Json;

namespace IdentityProj.Middlewares;

public class ExceptionHandler
{
    private readonly ILogger _logger;
    private readonly RequestDelegate _next;

    public ExceptionHandler(
        RequestDelegate next,
        ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger(nameof(ExceptionHandler));
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NullReferenceException e)
        {
            _logger.LogError(e.ToString());
            
            await HandleExceptionAsync(context, e, HttpStatusCode.InternalServerError);
        }
        catch (FormatException e)
        {
            _logger.LogError(e.ToString());

            await HandleExceptionAsync(context, e, HttpStatusCode.InternalServerError);
        }
        catch (InvalidCastException e)
        {
            _logger.LogError(e.ToString());

            await HandleExceptionAsync(context, e, HttpStatusCode.BadRequest);
        }
        catch (InvalidOperationException e)
        {
            _logger.LogError(e.ToString());

            await HandleExceptionAsync(context, e, HttpStatusCode.BadRequest);
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());

            await HandleExceptionAsync(context, e, HttpStatusCode.InternalServerError);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
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