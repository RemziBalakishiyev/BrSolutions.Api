using AutoMapper;
using BrSolution.Application.Exceptions;
using BrSolution.Application.Models;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces.App;
using BrSolution.Infrastructure.Helpers;
using BrSolution.Infrastructure.PredefinedValues;

namespace BrSolution.Application.Features.Command.App.Auth;

public class SetAuthenticatedUserCommandHandler : ServiceQueryHandlerBase<SetAuthenticatedUserCommand, IAdminService>
{
    private const string UserIdClaimType = "ir";
    private const string UserStatusClaimType = "sw";
    private const string UserServicePermissionClaimType = "sp";
    private readonly IAuthenticationService authenticationService;
    private AuthenticatedUser _authenticatedUser;

    public SetAuthenticatedUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticationService authenticationService) : base(unitOfWork, mapper,authenticationService)
    {
        this.authenticationService = authenticationService;
    }

    public async override Task Handle(SetAuthenticatedUserCommand request, CancellationToken cancellationToken)
    {
        var claimsPrincipal = request.ClaimsPrincipal;
        var id = claimsPrincipal.Claims.FirstOrDefault(c => c.Type.Equals(UserIdClaimType));
        var userStatus = claimsPrincipal.Claims.FirstOrDefault(c => c.Type.Equals(UserStatusClaimType));

        if (ObjectHelper.IsAnyNull(id, userStatus))
        {
            throw new BrSolutionException(ExceptionType.UnAuthorized);
        }

        _authenticatedUser = new AuthenticatedUser
        {
            Id = int.Parse(id!.Value),
            UserStatus = (UserStatusValue)int.Parse(userStatus!.Value),
            Services = claimsPrincipal.Claims.Where(c => c.Type.Equals(UserServicePermissionClaimType))
                .Select(x => x.Value).ToHashSet()
        };

        authenticationService.SetAuthenticatedUser(_authenticatedUser);

    }

   
}

