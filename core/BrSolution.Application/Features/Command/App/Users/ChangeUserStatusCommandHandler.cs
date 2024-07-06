using AutoMapper;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces.App;

namespace BrSolution.Application.Features.Command.App.Users;

public class ChangeUserStatusCommandHandler : ServiceQueryHandlerBase<ChangeUserStatusCommand, IAdminService>
{
    public ChangeUserStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticationService authenticationService) : base(unitOfWork, mapper, authenticationService)
    {
    }

    public override async Task Handle(ChangeUserStatusCommand request, CancellationToken cancellationToken)
    {
        var user =await  _unitOfWork.UserRepository
            .GetAsync(x => x.Id == request.UserId && x.UserStatusId != request.UserStatusValue);

        user.UserStatusId = request.UserStatusValue;
        await SaveChangesAsync(cancellationToken);

    }
}
