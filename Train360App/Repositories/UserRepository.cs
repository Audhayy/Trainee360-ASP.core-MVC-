using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Trainee360App.Helper;
using Trainee360App.Models;

namespace Trainee360App.Repositories 
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
