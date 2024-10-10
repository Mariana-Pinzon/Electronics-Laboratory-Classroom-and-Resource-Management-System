using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    public class Auth_Controller
    {
        [Route("api/[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly IUserService _userService;

            public AuthController(IUserService userService)
            {
                _userService = userService;
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginRequest request)
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                // Validar usuario
                bool isValidUser = await _userService.ValidateUserAsync(request.Email, request.Password);
                if (!isValidUser)
                {
                    return Unauthorized("Invalid credentials.");
                }

                // Si las credenciales son válidas, el login es exitoso
                return Ok("Login successful");
            }
        }
    }
}
