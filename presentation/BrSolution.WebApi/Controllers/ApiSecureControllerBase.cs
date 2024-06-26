using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace BrSolution.WebApi.Controllers
{
    [Authorize]
    public abstract class ApiSecureControllerBase : ApiControllerBase
    {

        public ApiSecureControllerBase(IMediator mediator) : base(mediator)
        {
        }
    }
}
