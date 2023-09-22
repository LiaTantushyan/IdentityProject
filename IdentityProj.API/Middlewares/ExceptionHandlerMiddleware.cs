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
        catch (Exception exception)
        {
            // log the error
            _logger.LogError(exception, "Error during executing {Context}", context.Request.Path.Value);
            
            var response = context.Response;
            response.ContentType = "application/json";

            // get the response model
            var message = JsonConvert.SerializeObject(new ResponseModel()
            {
                Succeeded = false,
                Errors = new[] { ErrorMessages.UnknownError }
            });

            await response.WriteAsync(message);
        }
    }
}