using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces;
using MediatR;

namespace BrSolution.Application.Features;

public abstract class ServiceQueryHandlerBase<TQuery, TService>(IUnitOfWork unitOfWork) : IRequestHandler<TQuery>
 where TQuery : class,  IRequest, IQueryBase

 where TService : IServiceBase
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;

    public virtual Task Handle(TQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
