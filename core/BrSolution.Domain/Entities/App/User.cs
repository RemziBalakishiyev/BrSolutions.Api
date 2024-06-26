using BrSolution.Infrastructure.PredefinedValues;

namespace BrSolution.Domain.Entities.App;

public class User : IEditedEntity
{
    public int Id { get; set; }
    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public UserStatusValue UserStatusId { get; set; }

    public UserStatus UserStatus { get; set; }
    public DateTime CreateDate { get; set; }

    public UserDetail? UserDetail { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    public DateTime? LastEditedDate { get; set; }
}
