using BrSolution.Infrastructure.PredefinedValues;

namespace BrSolution.Domain.Entities.App;

public class UserStatus : IEntity
{
    public UserStatusValue Id { get; set; }
    public string Name { get; set; }
    public DateTime CreateDate { get; set; }
}
