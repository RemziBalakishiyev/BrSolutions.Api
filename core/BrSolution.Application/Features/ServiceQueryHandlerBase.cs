using AutoMapper;
using BrSolution.Application.Features.Command.App.Auth;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces;
using BrSolution.Application.ServiceInterfaces.App;
using MediatR;

namespace BrSolution.Application.Features;

public abstract class ServiceQueryHandlerBase<TQuery, TService>(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticationService authenticationService)
    : IRequestHandler<TQuery>
      where TQuery : class, IRequest

 where TService : IServiceBase
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;
    private readonly IAuthenticationService _authenticationService = authenticationService;
   

    public virtual Task Handle(TQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    protected async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        await _unitOfWork.SaveChangesAsync(_authenticationService.GetAuthenticatedUserId() ?? default, cancellationToken);
        await _unitOfWork.CommitChangesAsync(cancellationToken);
    }
}
