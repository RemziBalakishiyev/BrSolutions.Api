using AutoMapper;
using BrSolution.Application.Data_Transfer_Objects.Users;
using BrSolution.Application.Exceptions;
using BrSolution.Application.Extensions;
using BrSolution.Application.Features.Command.App.Auth;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces.App;
using BrSolution.Domain.Entities.App;
using BrSolution.Infrastructure.Helpers;
using FluentValidation;
using MediatR;

namespace BrSolution.Application.Features.Command.App.Users;

public class UserCreateCommandHandler : ServiceQueryWithResponseHandlerBase<UserCreateCommand, AuthenticatedUserDto, IAdminService>
{
    private readonly AbstractValidator<UserCreateCommand> _userValidators;
    private readonly IMediator mediator;

    public UserCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator, IAuthenticationService authenticationService) : base(unitOfWork, mapper, authenticationService)
    {
        this.mediator = mediator;
    }

    public override async Task<AuthenticatedUserDto> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        await _userValidators.ThrowIfValidationFailAsync(request);

        if (await _unitOfWork.UserRepository.IsEmailExistsAsync(request.Email))
        {
            throw new BrSolutionException("Email can't found");
        }
        var entity = _mapper.Map<User>(request);
        entity.UserDetail = _mapper.Map<UserDetail>(request);
        entity.PasswordHash = SecurityHelper.ComputeSha256Hash(request.Password);

        entity.UserStatusId = Infrastructure.PredefinedValues.UserStatusValue.Register;
        await _unitOfWork.SaveChangesAsync(default, cancellationToken);

        return await mediator.Send(new GenerateTokenCommand
        {
            Email = request.Email,
            Password = request.Password,
        }, cancellationToken);

    }
}
