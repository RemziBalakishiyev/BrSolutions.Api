using BrSolution.Infrastructure.PredefinedValues;

namespace BrSolution.Application.Models;

public class AuthenticatedUser
{
    public int Id { get; init; }

    public UserStatusValue UserStatus { get; init; }

    public ISet<string> Services { get; init; }
}
