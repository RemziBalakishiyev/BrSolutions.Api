using BrSolution.Application.AutoMappers;
using BrSolution.Application.Data_Transfer_Objects.Users;
using BrSolution.Domain.Entities.App;
using MediatR;

namespace BrSolution.Application.Features.Command.App.Auth;

public class SetUserRolesCommand : IRequest
{
    public int UserId { get; set; }
    public IReadOnlyCollection<UserRoleDto> UserRoles { get; set; }
}
