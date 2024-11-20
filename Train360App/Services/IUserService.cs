
using Trainee360App.Models;

namespace Trainee360App.Services
{
    public interface IUserService
    {
         Task<User> ValidateUserCredentialsAsync(string email, string password);
    }
}
