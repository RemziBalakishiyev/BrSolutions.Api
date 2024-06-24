using AutoMapper;
using BrSolution.Application.Features.Query.App;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces.App;

namespace BrSolution.Application.Features.Handler.App;

public class RollbackQueryHandler : ServiceQueryHandlerBase<RollbackQuery, IAdminService>
{
    public RollbackQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticationService authenticationService) : base(unitOfWork, mapper, authenticationService)
    {
    }

    public override async Task Handle(RollbackQuery request, CancellationToken cancellationToken)
    {
        await _unitOfWork.RollbackChangesAsync(cancellationToken);
    }
}
