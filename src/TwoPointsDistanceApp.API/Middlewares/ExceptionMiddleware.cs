using System.Net;
using System.Text.Json;
using TwoPointsDistanceApp.Domain.Exceptions;
using TwoPointsDistanceApp.Responses;

namespace TwoPointsDistanceApp.Middlewares;

public class ExceptionMiddleware
{
    private static readonly Action<ILogger, string, Exception> LogError = LoggerMessage.Define<string>(
        LogLevel.Error,
        0,
        "Exception: {Message}");

    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            LogException(ex);
            await HandleExceptionAsync(context, ex);
        }
    }

    private void LogException(Exception ex)
    {
        LogError(_logger, ex.Message, ex);
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        var error = new ErrorApiResponse();

        switch (exception)
        {
            case DomainException domainException:
                response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                error.Code = domainException.GetType().Name;
                error.Details = domainException.Message;
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                error.Code = "InternalServerErrorException";
                break;
        }

        await context.Response.WriteAsync(JsonSerializer.Serialize(error));
    }
}