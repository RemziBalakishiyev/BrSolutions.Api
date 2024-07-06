using BrSolution.Application.AutoMappers;
using BrSolution.Domain.Entities.App;

namespace BrSolution.Application.Data_Transfer_Objects.Users
{
    public class UserRoleDto : IMapTo<UserRole>
    {
        public int RoleId { get; set; }
    }
}
