using AutoMapper;
using BrSolution.Application.Exceptions;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces;
using BrSolution.Application.ServiceInterfaces.App;
using BrSolution.Infrastructure.Helpers;
using BrSolution.Infrastructure.PredefinedValues;
using MediatR;

namespace BrSolution.Application.Features
{
    internal class SecuredServiceBaseResponseHandlere<TQuery, TResponse, TService> : ServiceQueryWithResponseHandlerBase<TQuery, TResponse, TService>
    where TQuery : class, IRequest<TResponse>
    where TService : IServiceBase
    {
        public SecuredServiceBaseResponseHandlere(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticationService authenticationService) : base(unitOfWork, mapper, authenticationService)
        {
            var encryptedServiceName = SystemServiceHelper.EncryptSystemServiceName(GetType().BaseType.GetGenericArguments().Last());

            if (_authenticationService.AuthenticatedUser.UserStatus != UserStatusValue.Active
                || !_authenticationService.AuthenticatedUser.Services.Contains(encryptedServiceName))
            {
                throw new BrSolutionException("User hasn't permission");
            }
        }
    }
}
