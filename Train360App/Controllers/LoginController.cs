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
            try
            {
                User isValidUser = await _userService.ValidateUserCredentialsAsync(request.Email, request.Password);
                return Ok(new { role = isValidUser.Role.Name });
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
