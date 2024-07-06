using AutoMapper;
using BrSolution.Application.AutoMappers;
using BrSolution.Domain.Entities.App;
using MediatR;

namespace BrSolution.Application.Features.Command.App.Auth;

public class AddUserRoleCommand : ICustomMapping, IRequest
{
    private string _name;

    public int Id { get; set; }

    public string Name
    {
        get => _name;
        set => _name = value.Trim();
    }

    public ISet<int> SelectedSystemServices { get; set; } = new HashSet<int>();

    public void CreateMappings(Profile configuration)
    {
        configuration.CreateMap<Role, AddUserRoleCommand>()
         .ForMember(x => x.SelectedSystemServices,
             opt => opt.MapFrom(x => x.RoleSystemServices.Select(x=>x.SystemService.Id)))
         .ReverseMap();
    }
}
