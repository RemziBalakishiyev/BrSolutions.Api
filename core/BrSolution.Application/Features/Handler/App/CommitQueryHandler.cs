using AutoMapper;
using BrSolution.Application.Features.Query.App;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces.App;

namespace BrSolution.Application.Features.Handler.App;

public class CommitQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : ServiceQueryHandlerBase<CommitQuery, IAdminService>(unitOfWork, mapper)
{
    public override async Task Handle(CommitQuery request, CancellationToken cancellationToken)
    {
        await  _unitOfWork.CommitChangesAsync();
    }
}
