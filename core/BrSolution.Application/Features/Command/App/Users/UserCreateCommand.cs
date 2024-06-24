using BrSolution.Application.AutoMappers;
using BrSolution.Application.Data_Transfer_Objects.Users;
using BrSolution.Domain.Entities.App;
using MediatR;

namespace BrSolution.Application.Features.Command.App.Users;

public class UserCreateCommand : IMapTo<User>,IMapTo<UserDetail>, IRequest<AuthenticatedUserDto> ,IQueryBase
{
    private string _email;
    private string _firstName;
    private string? _lastName;

    public string Email
    {
        get => _email;
        set => _email = value.Trim().ToLower();
    }

    public string Password { get; set; }

    public string FirstName
    {
        get => _firstName;
        set => _firstName = value.Trim();
    }

    public string? LastName
    {
        get => _lastName;
        set => _lastName = value?.Trim();
    }

 
    public DateTime DateOfBirth { get; set; }

}
