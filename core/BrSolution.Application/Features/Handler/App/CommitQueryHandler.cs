using AutoMapper;
using BrSolution.Application.Features.Query.App;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces.App;

namespace BrSolution.Application.Features.Handler.App;

public class CommitQueryHandler : ServiceQueryHandlerBase<CommitQuery, IAdminService>
{
    public CommitQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticationService authenticationService) : base(unitOfWork, mapper, authenticationService)
    {
    }

    public override async Task Handle(CommitQuery request, CancellationToken cancellationToken)
    {
        await  _unitOfWork.CommitChangesAsync();
    }
}
