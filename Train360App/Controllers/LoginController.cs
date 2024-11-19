using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Trainee360App.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || request.Email.Length > 40 || request.Password.Length != 8)
            {
                return BadRequest("Invalid email or password format.");
            }

            // Example: Replace with your user authentication logic
            if (request.Email == "user@example.com" && request.Password == "password") // Demo values
            {
                return Ok(); // Login successful
            }
            else
            {
                return Unauthorized(); // Invalid credentials
            }
        }
    }
}
