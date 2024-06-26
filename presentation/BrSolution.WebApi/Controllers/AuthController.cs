using BrSolution.Application.Data_Transfer_Objects.Users;
using BrSolution.Application.Features.Command.App.Users;
using BrSolution.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrSolution.WebApi.Controllers
{
    [Route("api/auth/[controller]/[action]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        [ActionName("signup")]
        public async Task<ActionResult<ApiResponseModel<AuthenticatedUserDto>>> SignUp([FromBody] UserCreateCommand command)
        {
            var authenticatedUser = await _mediator.Send(command);
            return await AsSuccessResultAsync(authenticatedUser);
        }
    }
}
