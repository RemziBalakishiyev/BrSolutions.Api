using BrSolution.Domain.Entities.App;

namespace BrSolution.Domain.Entities;

public interface ICreatedUserEntity : IEntity
{
    public int? CreatedUserId { get; set; }
    public User? CreatedUser { get; set; }
}
