using BrSolution.Application.Exceptions;
using BrSolution.Application.Features.Command.App;
using BrSolution.Application.Features.Query.App;
using BrSolution.Infrastructure.Helpers;
using BrSolution.Infrastructure.Settings;
using BrSolution.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using System.Net;

namespace BrSolution.WebApi.Middlewares;

public class ExceptionHandlerMiddleware
{
    private const string AppJsonContentType = "application/json";
    private readonly RequestDelegate _next;
    private readonly IServiceProvider _serviceProvider;

    public ExceptionHandlerMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
    {
        _next = next;
        _serviceProvider = serviceProvider;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            var commitQuery = new CommitQuery();
            var rollbackQuery = new RollbackQuery();
            var transactionId = await mediator.Send(new GetTransactionIdQuery());

            string? requestBody = null;
            if (string.Equals(context.Request.ContentType, AppJsonContentType, StringComparison.OrdinalIgnoreCase))
            {
                requestBody = await ReadRequestBodyAsync(context);
            }

            try
            {
                await _next(context);
                await mediator.Send(commitQuery);
            }
            catch (Exception e)
            {
                await mediator.Send(rollbackQuery);
                await HandleExceptionAsync(context, e, transactionId, requestBody, mediator);
            }
        }
    }

    private static async Task<string?> ReadRequestBodyAsync(HttpContext context)
    {
        context.Request.EnableBuffering();
        var request = context.Request;

        using var memoryStream = new MemoryStream();
        await request.Body.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        request.Body.Position = 0;

        using var reader = new StreamReader(memoryStream);
        return await reader.ReadToEndAsync();
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception, Guid transactionId, string? requestBody, IMediator mediator)
    {
        while (exception.InnerException is not null)
        {
            exception = exception.InnerException;
        }

        var (messages, statusCode) = GetErrorResponseDetails(exception);

        if (exception is not ValidationException && exception is not BrSolutionException)
        {
            await LogExceptionAsync(context, exception, transactionId, requestBody, mediator);
        }

        await WriteResponseAsync(context, messages, statusCode);
    }

    private (List<string>, HttpStatusCode) GetErrorResponseDetails(Exception exception)
    {
        var messages = new List<string>();
        var statusCode = HttpStatusCode.BadRequest;

        switch (exception)
        {
            case ValidationException validationException:
                messages.AddRange(validationException.Errors.Select(v => $"{v.PropertyName} - {v.ErrorMessage}"));
                break;

            case BrSolutionException brSolutionException:
                statusCode = brSolutionException.Message switch
                {
                    ExceptionType.UnAuthorized => HttpStatusCode.Unauthorized,
                    ExceptionType.InternalServerError => HttpStatusCode.InternalServerError,
                    _ => HttpStatusCode.BadRequest
                };
                messages.Add(ResponseMessageManager.GetResponseMessageByMessageCode($"c-000{(int)brSolutionException.Message}"));
                var ex = exception.Message;
                break;

            default:
                statusCode = HttpStatusCode.InternalServerError;
                messages.Add(ResponseMessageManager.GetResponseMessageByMessageCode("c-0001"));
#if DEBUG
                messages.Add($"{exception.Message}\n\n{exception.StackTrace}");
#endif
                break;
        }

        return (messages, statusCode);
    }

    private async Task LogExceptionAsync(HttpContext context, Exception exception, Guid transactionId, string? requestBody, IMediator mediator)
    {
        var exceptionLog = new AddExceptionLogCommand
        {
            RequestIp = context.Connection.RemoteIpAddress?.ToString(),
            RequestUrl = context.Request.GetDisplayUrl(),
            ExceptionTypeName = exception.GetType().Name,
            ExceptionMessage = exception.Message,
            StackTrace = exception.StackTrace,
            RequestBody = requestBody,
            HttpMethod = context.Request.Method,
            EndpointName = context.GetEndpoint()?.DisplayName,
            TransactionId = transactionId,
        };
        await mediator.Send(exceptionLog);
    }

    private static async Task WriteResponseAsync(HttpContext context, IEnumerable<string> messages, HttpStatusCode statusCode)
    {
        if (context.Response.HasStarted)
        {
            return;
        }

        var response = new ApiResponseModel<object?>
        {
            Messages = messages,
            StatusCode = (int)statusCode,
            Result = null
        };

        var responseAsJson = JsonSerializerHelper.Serialize(response);

        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = AppJsonContentType;
        await context.Response.WriteAsync(responseAsJson);
    }
}
