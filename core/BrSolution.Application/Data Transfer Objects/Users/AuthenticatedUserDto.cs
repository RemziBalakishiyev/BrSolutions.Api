using AutoMapper;
using BrSolution.Application.AutoMappers;
using BrSolution.Domain.Entities.App;
using BrSolution.Infrastructure.PredefinedValues;

namespace BrSolution.Application.Data_Transfer_Objects.Users;

public class AuthenticatedUserDto : ICustomMapping
{
    public string Email { get; set; }

    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public string Token { get; set; }

    public UserStatusValue UserStatusId { get; set; }

    public IEnumerable<string> Services { get; set; }

    public void CreateMappings(Profile configuration)
    {
        configuration.CreateMap<User,AuthenticatedUserDto>()
           .ForMember(x => x.FirstName,
                config => config.MapFrom(
                    x => x.UserDetail != null ? x.UserDetail.FirstName : null
                ))
            .ForMember(x => x.FirstName,
                config => config.MapFrom(
                    x => x.UserDetail != null ? x.UserDetail.LastName : null
                    ));
    }
}
