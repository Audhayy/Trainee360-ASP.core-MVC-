
using Microsoft.CodeAnalysis.Scripting;
using Trainee360App.Models;
using Trainee360App.Repositories;

namespace Trainee360App.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<User> ValidateUserCredentialsAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
 
            if (user == null)
            {
                throw new UserNotFoundException(new Messages {});
            }
            if (!IsValidPassword(password, user.Password))
            {
                throw new UnauthorizedAccessException("Password Mismatch");
            }
            return user;
        }

        private bool IsValidPassword(string credentialPassword, string userPassword)
        {
           return credentialPassword == userPassword;
        }
    }
}
