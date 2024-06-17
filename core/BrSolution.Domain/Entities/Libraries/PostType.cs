using BrSolution.Infrastructure.PredefinedValues;

namespace BrSolution.Domain.Entities.Libraries;

public class PostType : IEntity
{
    public PostTypeValue Id { get; set; }
    public string Name { get; set; }
    public DateTime CreateDate { get; set; }
}
