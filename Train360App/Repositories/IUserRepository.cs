
using Trainee360App.Models;

namespace Trainee360App.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
