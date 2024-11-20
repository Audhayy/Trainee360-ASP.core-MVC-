
namespace Trainee360App.Services
{
    public interface IUserService
    {
         Task<bool> ValidateUserCredentialsAsync(string email, string password);
    }
}
