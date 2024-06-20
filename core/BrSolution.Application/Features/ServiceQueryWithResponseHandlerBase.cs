using BrSolution.Application.Data_Transfer_Objects;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces;
using MediatR;

namespace BrSolution.Application.Features;

public abstract class ServiceQueryWithResponseHandlerBase<TQuery, TResponse, TService>(IUnitOfWork unitOfWork) : IRequestHandler<TQuery, TResponse>
    where TQuery : class, IRequest<TResponse>, IRequest,  IQueryBase
    where TResponse : class, IDto
    where TService : IServiceBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public virtual Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
