using AutoMapper;
using BrSolution.Application.Data_Transfer_Objects;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces;
using MediatR;

namespace BrSolution.Application.Features;

public abstract class ServiceQueryWithResponseHandlerBase<TQuery, TResponse, TService>(IUnitOfWork unitOfWork, IMapper mapper) 
    : IRequestHandler<TQuery, TResponse>
    where TQuery : class, IRequest<TResponse>
    where TService : IServiceBase
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;

    public virtual Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
