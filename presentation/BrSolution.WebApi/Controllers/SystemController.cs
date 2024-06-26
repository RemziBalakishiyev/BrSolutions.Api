using BrSolution.Application.Features.Command.App.Admin;
using BrSolution.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrSolution.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class SystemController : ApiControllerBase
    {
        public SystemController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponseModel<object>>> InitializeMetadata()
        {

            await _mediator.Send(new InitializeSystemServicesMetadataCommand());
            return await AsSuccessResultAsync();
        }
    }
}
