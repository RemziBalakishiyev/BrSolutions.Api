using BrSolution.Application.Exceptions;
using BrSolution.Application.Models;
using BrSolution.Application.ServiceInterfaces.App;

namespace BrSolution.Application.ServiceImplementations.App
{
    public class AuthenticationService : IAuthenticationService
    {
        private AuthenticatedUser? _authenticatedUser;
        public AuthenticatedUser AuthenticatedUser =>
        _authenticatedUser ?? throw new BrSolutionException(ExceptionType.UnAuthorized);
        public int? GetAuthenticatedUserId()
                 => _authenticatedUser?.Id;
       

        public void SetAuthenticatedUser(AuthenticatedUser authenticatedUser)
        {
           _authenticatedUser = authenticatedUser;
        }
    }
}
