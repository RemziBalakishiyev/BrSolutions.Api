using AutoMapper;
using BrSolution.Application.Features.Query.App;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces.App;

namespace BrSolution.Application.Features.Handler.App
{
    public class GetTransactionIdQueryHandler : ServiceQueryWithResponseHandlerBase<GetTransactionIdQuery, Guid, IAdminService>
    {
        public GetTransactionIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticationService authenticationService) : base(unitOfWork, mapper, authenticationService)
        {
        }

        public override Task<Guid> Handle(GetTransactionIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_unitOfWork.TransactionId);
        }
    }
}
