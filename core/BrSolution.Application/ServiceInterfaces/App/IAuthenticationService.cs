using BrSolution.Application.Models;
using System.Security.Claims;

namespace BrSolution.Application.ServiceInterfaces.App;

public interface IAuthenticationService
{
    AuthenticatedUser AuthenticatedUser { get; }
    int? GetAuthenticatedUserId();
    void SetAuthenticatedUser(AuthenticatedUser claimsPrincipal);
}
