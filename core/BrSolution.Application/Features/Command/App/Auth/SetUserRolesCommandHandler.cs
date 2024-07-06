using AutoMapper;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces.App;
using BrSolution.Domain.Entities.App;

namespace BrSolution.Application.Features.Command.App.Auth
{
    public class SetUserRolesCommandHandler : ServiceQueryHandlerBase<SetUserRolesCommand, IAdminService>
    {
        public SetUserRolesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticationService authenticationService) : base(unitOfWork, mapper, authenticationService)
        {
        }


        public override async Task Handle(SetUserRolesCommand request, CancellationToken cancellationToken)
        {
            var currentRoles = await _unitOfWork.UserRoleRepository.GetAllAsDictionaryAsync(x => x.RoleId, x => x.UserId == request.UserId);
            foreach (var userRole in request.UserRoles)
            {
                if (currentRoles.ContainsKey(userRole.RoleId))
                {
                    currentRoles.Remove(userRole.RoleId);
                    continue;
                }

                await _unitOfWork.UserRoleRepository.Add(new UserRole
                {
                    UserId = request.UserId,
                    RoleId = userRole.RoleId
                });
            }

            foreach (var currentRole in currentRoles)
            {
                _unitOfWork.UserRoleRepository.Delete(currentRole.Value);
            }

            await SaveChangesAsync(cancellationToken);

        }

    }
}
