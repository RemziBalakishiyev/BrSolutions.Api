using BrSolution.Infrastructure.PredefinedValues;

namespace BrSolution.Domain.Entities.Libraries;

public class PostStatus : IEntity
{
    public PostStatusValue Id { get; set; }
    public string Name { get; set; }
    public DateTime CreateDate { get; set; }
}
