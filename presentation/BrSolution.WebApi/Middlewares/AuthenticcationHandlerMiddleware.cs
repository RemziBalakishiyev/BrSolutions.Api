using BrSolution.Application.Features.Command.App.Auth;
using BrSolution.Application.ServiceInterfaces.App;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace BrSolution.WebApi.Middlewares
{
    public class AuthenticcationHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMediator _mediator;
        public AuthenticcationHandlerMiddleware(RequestDelegate next, IMediator mediator)
        {
            _next = next;
            _mediator = mediator;
          
        }

        public Task InvokeAsync(HttpContext context)
        {
            var endpointMetadata = context.GetEndpoint()?.Metadata.ToList();

            if (endpointMetadata is not null)
            {
                var authAttrIndex = endpointMetadata.FindIndex(
                    x => x.GetType() == typeof(AuthorizeAttribute));

                if (authAttrIndex != -1
                    && endpointMetadata.FindIndex(authAttrIndex + 1,
                        x => x.GetType() == typeof(AllowAnonymousAttribute)) == -1)
                {
                    var authService = context.RequestServices.GetRequiredService<IAuthenticationService>();
                    _mediator.Send(new SetAuthenticatedUserCommand(context.User));
                }
            }

            return _next(context);
        }
    }
}
