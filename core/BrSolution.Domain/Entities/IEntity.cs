using BrSolution.Domain.Entities.App;

namespace BrSolution.Domain.Entities;

public interface IEntity
{
    public DateTime CreateDate { get; set; }
}
