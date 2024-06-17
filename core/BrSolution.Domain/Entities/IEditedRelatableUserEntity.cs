using BrSolution.Domain.Entities.App;

namespace BrSolution.Domain.Entities;

public interface IEditedRelatableUserEntity : ICreatedUserEntity, IEditedEntity
{
    public int? LastEditUserId { get; set; }

    public User? LastEditUser { get; set; }
}
