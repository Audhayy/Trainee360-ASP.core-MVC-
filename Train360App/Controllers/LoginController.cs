using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Trainee360App.Models;
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
            User isValidUser = await _userService.ValidateUserCredentialsAsync(request.Email, request.Password);
            if (isValidUser != null)
            {
                return Ok(new { Message = "Welcome Mentor", role = isValidUser.Role.Name });
            }
            return Unauthorized(new { Message = "Login Failed" });
        }
    }
}
