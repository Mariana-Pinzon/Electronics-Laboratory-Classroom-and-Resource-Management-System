using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class User_Controller : ControllerBase
    {
        private readonly IUserService _userService;

        public User_Controller(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers([FromQuery] int userTypeId, [FromQuery] int userPermissionId)
        {
            try
            {
                var users = await _userService.GetAllusersAsync(userTypeId, userPermissionId);
                return Ok(users);
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid(); // Retorna 403 si no tiene permisos
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUserById([FromQuery] int userTypeId, [FromQuery] int userPermissionId, int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(userTypeId, userPermissionId, id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid(); // Retorna 403 si no tiene permisos
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.User_ID }, user); 
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Manejo de errores de autorización
        public async Task<IActionResult> UpdateUser(int id, [FromQuery] int userTypeId, [FromQuery] int userPermissionId, [FromBody] User user)
        {
            if (id != user.User_ID) 
                return BadRequest();

            try
            {
                await _userService.UpdateUserAsync(userTypeId, userPermissionId, user);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid(); // Retorna 403 si no tiene permisos
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Manejo de errores de autorización
        public async Task<IActionResult> SoftDeleteUser(int id, [FromQuery] int userTypeId, [FromQuery] int userPermissionId)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(userTypeId, userPermissionId, id);
                if (user == null)
                    return NotFound();

                await _userService.SoftDeleteUserAsync(userTypeId, userPermissionId, id);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid(); // Retorna 403 si no tiene permisos
            }
        }
    }
}