using AutoMapper;
using BrSolution.Application.Extensions;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces.App;
using BrSolution.Domain.Entities.App;
using FluentValidation;

namespace BrSolution.Application.Features.Command.App.Auth
{
    public class AddUserRoleCommandHandler : ServiceQueryHandlerBase<AddUserRoleCommand, IAdminService>
    {
        private readonly AbstractValidator<AddUserRoleCommand> _validationRules;
        public AddUserRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticationService authenticationService, AbstractValidator<AddUserRoleCommand> validationRules) : base(unitOfWork, mapper, authenticationService)
        {
            _validationRules = validationRules;
        }

        public override async Task Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            request.Id = 0;
            var entity = _mapper.Map<Role>(request);

            foreach (var systemServiceId in request.SelectedSystemServices)
            {
                entity.RoleSystemServices.Add(new RoleSystemService
                {
                    SystemServiceId = systemServiceId
                });
            }

            await _unitOfWork.RoleRepository.Add(entity);

            await SaveChangesAsync(cancellationToken);
        }
    }
}
