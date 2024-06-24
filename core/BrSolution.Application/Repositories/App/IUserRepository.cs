using BrSolution.Domain.Entities.App;

namespace BrSolution.Application.Repositories.App;

public interface IUserRepository : IRepository<User>
{
    Task<User?> TryToGetWithDetailsAsync(string email, string password);

    Task<bool> IsEmailExistsAsync(string email);
}
