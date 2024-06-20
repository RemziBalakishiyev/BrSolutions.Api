using AutoMapper;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces;
using MediatR;

namespace BrSolution.Application.Features;

public abstract class ServiceQueryHandlerBase<TQuery, TService>(IUnitOfWork unitOfWork, IMapper mapper) 
    : IRequestHandler<TQuery>
      where TQuery : class, IRequest

 where TService : IServiceBase
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;
    

  

    public virtual Task Handle(TQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
