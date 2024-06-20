using BrSolution.Application.Exceptions;
using BrSolution.Application.Features.Query.App;
using BrSolution.Infrastructure.Helpers;
using BrSolution.Infrastructure.Settings;
using BrSolution.WebApi.Models;
using MediatR;
using System.Net;

namespace BrSolution.WebApi.Middlewares;

public class ExceptionHandlerMiddleware(RequestDelegate next, IMediator mediator)
{
    private const string AppJsonContentType = "application/json";
    private readonly RequestDelegate _next = next;
    private readonly IMediator _mediator;

    public async Task InvokeAsync(HttpContext context)
    {
        var commitQuery = new CommitQuery();
        var rollbackQuery = new RollbackQuery();

        string? requestBody = null;
        if (string.Equals(context.Request.ContentType,
          AppJsonContentType, StringComparison.OrdinalIgnoreCase))
        {
            using var ms = new MemoryStream();
            await context.Request.Body.CopyToAsync(ms);
            ms.Position = 0;

            context.Request.Body = new MemoryStream();
            await ms.CopyToAsync(context.Request.Body);
            context.Request.Body.Position = 0;
            ms.Position = 0;

            using var streamReader = new StreamReader(ms);
            requestBody = await streamReader.ReadToEndAsync();
        }


        try
        {
            await _mediator.Send(commitQuery);
        }
        catch (Exception e)
        {
            await _mediator.Send(rollbackQuery);
            while (e.InnerException is not null)
            {
                e = e.InnerException;
            }


            var messages = new List<string?>();
            var statusCode = HttpStatusCode.BadRequest;
            object? result = null;
            string message = "c-";
            switch (e)
            {
                case BrSolutionException brSolutionException:
                    statusCode = brSolutionException.Message switch
                    {
                        ExceptionType.UnAuthorized => HttpStatusCode.Unauthorized,
                        ExceptionType.InternalServerError => HttpStatusCode.InternalServerError,
                    };


                    messages.Add(ResponseMessageManager.GetResponseMessageByMessageCode(message + (int)brSolutionException.Message));
                    break;

                default:

                    statusCode = HttpStatusCode.InternalServerError;
                    messages.Add(ResponseMessageManager.GetResponseMessageByMessageCode("c-0001"));
#if DEBUG
                    messages.Add($"{e.Message}\n\n{e.StackTrace}");
#endif
                    break;
            }
            await WriteResponseAsync(context, messages, statusCode, result);


        }
    }

    private static async Task WriteResponseAsync(
   HttpContext httpContext,
   IEnumerable<string?> messages,
   HttpStatusCode statusCode,
   object? result)
    {
        if (httpContext.Response.HasStarted)
        {
            return;
        }

        var response = new ApiResponseModel<object?>
        {
            Messages = messages,
            StatusCode = (int)statusCode,
            Result = result
        };

        var responseAsJson = JsonSerializerHelper.Serialize(response);

        httpContext.Response.StatusCode = (int)statusCode;
        httpContext.Response.ContentType = AppJsonContentType;
        await httpContext.Response.WriteAsync(responseAsJson);
    }
}
