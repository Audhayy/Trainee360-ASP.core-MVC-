using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Trainee360App.Services;

namespace Trainee360App.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController (IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || request.Email.Length > 40 || request.Password.Length != 8)
            {
                return BadRequest("Invalid email or password format.");
            }

            bool isValidUser = await _userService.ValidateUserCredentialsAsync(request.Email, request.Password);
            if (!isValidUser)
            {
                return Unauthorized(new { Message = "Login Failed"});
            }
            return Ok();
        }
    }
}
