
namespace BrSolution.Domain.Entities.App;

public class Role : IEditedRelatableUserEntity
{
    public int Id { get; set; }
    public string RoleName { get; set; }
    public int SystemServiceId { get; set; }
    public SystemService SystemService { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    public int? LastEditUserId { get; set; }
    public User? LastEditUser { get; set; }
    public int? CreatedUserId { get; set; }
    public User? CreatedUser { get; set; }
    public DateTime? LastEditedDate { get; set; }
    public DateTime CreateDate { get; set; }
}
