using BrSolution.Infrastructure.Settings;
using BrSolution.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BrSolution.WebApi.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public abstract class ApiControllerBase : ControllerBase
{
    private readonly IMediator _mediator;
    protected ApiControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }


    protected async Task<ActionResult<ApiResponseModel<object>>> AsSuccessResultAsync(
       string errorResponseCode)
       => await AsActionResultAsync<object>(HttpStatusCode.OK, errorResponseCode, null);
    protected async Task<ActionResult<ApiResponseModel<T>>> AsSuccessResultAsync<T>(
       string errorResponseCode,
       T? result)
       => await AsActionResultAsync(HttpStatusCode.OK, errorResponseCode, result);

    protected async Task<ActionResult<ApiResponseModel<T>>> AsSuccessResultAsync<T>(
      T? result)
      => await AsActionResultAsync(HttpStatusCode.OK, null, result);
    private async Task<ActionResult<ApiResponseModel<T>>> AsActionResultAsync<T>(
       HttpStatusCode statusCode,
       string errorResponseCode,
       T? result)
    {
        string? message = null;
        if (errorResponseCode is not null)
        {
            message = ResponseMessageManager.GetResponseMessageByMessageCode(errorResponseCode);
        }


        var statusCodeAsInt = (int)statusCode;
        var responseModel = new ApiResponseModel<T>
        {
            Result = result,
            StatusCode = statusCodeAsInt,
            Messages = message is not null ? new[] { message } : Array.Empty<string>()
        };

        return StatusCode(statusCodeAsInt, responseModel);
    }
}
