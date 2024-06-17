using BrSolution.Domain.Entities.App;
using BrSolution.Domain.Entities.Libraries;
using BrSolution.Infrastructure.PredefinedValues;

namespace BrSolution.Domain.Entities.Marketing;

public class PostPlan : IEditedRelatableUserEntity
{
    public int Id { get; set; }
    public string Definition { get; set; }
    public string Description { get; set; }
    public string Caption { get; set; }
    public DateTime SharedDate { get; set; }
    public PostStatusValue PostStatusId { get; set; }
    public PostStatus PostStatus { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int? LastEditUserId { get; set; }
    public User? LastEditUser { get; set; }
    public int? CreatedUserId { get; set; }
    public User? CreatedUser { get; set; }
    public DateTime? LastEditedDate { get; set; }
    public DateTime CreateDate { get; set; }
}
