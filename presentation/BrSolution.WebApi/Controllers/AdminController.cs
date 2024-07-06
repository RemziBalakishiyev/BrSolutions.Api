using BrSolution.Application.Features.Command.App.Auth;
using BrSolution.Application.Features.Command.App.Users;
using BrSolution.Application.ServiceInterfaces.App;
using BrSolution.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrSolution.WebApi.Controllers
{
    [Route("api/auth/[controller]/[action]")]
    [ApiController]
    public class AdminController : ApiSecureControllerBase
    {
        public AdminController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost]
        [ActionName("roles")]
        public async Task<ActionResult<ApiResponseModel<object>>> AddRole(AddUserRoleCommand role)
        {
            await _mediator.Send(role);

            return await AsSuccessResultAsync();
        }

        [HttpPut]
        [ActionName("change-status")]
        public async Task<ActionResult<ApiResponseModel<object>>> ChangeUserStatus(ChangeUserStatusCommand command)
        {
            await _mediator.Send(command);
            return await AsSuccessResultAsync();
        }


    }
}
