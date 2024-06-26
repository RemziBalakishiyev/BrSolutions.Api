using AutoMapper;
using BrSolution.Application.Data_Transfer_Objects;
using BrSolution.Application.Exceptions;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces;
using BrSolution.Application.ServiceInterfaces.App;
using BrSolution.Infrastructure.Helpers;
using BrSolution.Infrastructure.PredefinedValues;
using MediatR;

namespace BrSolution.Application.Features;

public abstract class ServiceQueryWithResponseHandlerBase<TQuery, TResponse, TService>
    : IRequestHandler<TQuery, TResponse>
    where TQuery : class, IRequest<TResponse>
    where TService : IServiceBase
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;
    protected readonly IAuthenticationService _authenticationService;

    protected ServiceQueryWithResponseHandlerBase(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticationService authenticationService)
    {
         _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authenticationService = authenticationService;
    }

    public virtual Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    protected async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _unitOfWork.SaveChangesAsync(_authenticationService.GetAuthenticatedUserId() ?? default, cancellationToken);
        //await _unitOfWork.CommitChangesAsync(cancellationToken);
    }
}
