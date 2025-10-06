using BulletinBoard.AppServices.Exceptions;
using BulletinBoard.Contracts.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BulletinBoard.Infrastructure.Middlewares;

/// <summary>
/// Middleware для глобальной обработки исключений.
/// </summary>
/// <param name="next">Следующий делегат в конвейере обработки запросов.</param>
/// <param name="logger">Логгер.</param>
public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger
)
{
    /// <summary>
    /// Обрабатывает входящий HTTP-запрос.
    /// </summary>
    /// <param name="context">Контекст HTTP-запроса.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            var userIp = context.Connection.RemoteIpAddress?.ToString() ?? "Address unknown";
            using (logger.BeginScope(new Dictionary<string, object> { ["UserIp"] = userIp }))
            {
                logger.LogError(e, "Что-то пошло не так");
            }

            await HandleExceptionAsync(context, e);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var errorModel = MapError(exception, context);
        context.Response.StatusCode = errorModel.Item1;

        return context.Response.WriteAsync(JsonConvert.SerializeObject(errorModel.Item2));
    }

    private static (int, ErrorDto) MapError(Exception exception, HttpContext context)
    {
        return exception switch
        {
            NotFoundException e => (StatusCodes.Status404NotFound, new ErrorDto
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = $"Сущность с идентификатором {e.Id} не была найдена.",
                TraceId = context.TraceIdentifier
            }),

            _ => (StatusCodes.Status500InternalServerError, new ErrorDto
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Что-то пошло не так.",
                TraceId = context.TraceIdentifier
            })
        };
    }
}