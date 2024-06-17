

namespace BrSolution.Domain.Entities.App;

public class Module : IEditedRelatableUserEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int? LastEditUserId { get; set; }
    public User? LastEditUser { get; set; }
    public int? CreatedUserId { get; set; }
    public User? CreatedUser { get; set; }
    public DateTime? LastEditedDate { get; set; }
    public DateTime CreateDate { get; set; }
}
