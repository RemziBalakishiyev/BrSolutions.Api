using BrSolution.Application.Data_Transfer_Objects.Users;
using BrSolution.Application.Features.Command.App.Auth;
using BrSolution.Application.Features.Command.App.Users;
using BrSolution.WebApi.Extensions;
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
        public async Task<ActionResult<ApiResponseModel<AuthenticatedUserDto>>> SignUp([FromForm] UserModel userModel)
        {
            var command = new UserCreateCommand
            {
                Email = userModel.Email,
                Password = userModel.Password,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                GenderId = userModel.GenderId,
                DateOfBirth = userModel.DateOfBirth,
                UserImage = userModel.UserImage.AsFileContentWrapper()
            };
         
            var authenticatedUser = await _mediator.Send(command);
            return await AsSuccessResultAsync(authenticatedUser);
        }

        [HttpPost]
        [ActionName("signin")]
        public async Task<ActionResult<ApiResponseModel<AuthenticatedUserDto>>> SignUp([FromBody] GenerateTokenCommand command)
        {
            var authenticatedUser = await _mediator.Send(command);
            return await AsSuccessResultAsync(authenticatedUser);
        }
    }
}
