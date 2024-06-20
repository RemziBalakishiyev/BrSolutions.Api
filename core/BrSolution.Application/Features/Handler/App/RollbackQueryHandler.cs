using BrSolution.Application.Features.Query.App;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces.App;

namespace BrSolution.Application.Features.Handler.App;

public class RollbackQueryHandler(IUnitOfWork unitOfWork) : ServiceQueryHandlerBase<RollbackQuery, IAdminService>(unitOfWork)
{
    public override async Task Handle(RollbackQuery request, CancellationToken cancellationToken)
    {
        await _unitOfWork.RollbackChangesAsync(cancellationToken);
    }
}
