using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class User_Controller : ControllerBase
    {
        private readonly Services.IUserService _userServise;
        public User_Controller(Services.IUserService userService)
        {
            _userServise = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            var users = await _userServise.GetAllUserAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userServise.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userServise.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.User_ID }, user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.User_ID)
                return BadRequest();

            var existingUser = await _userServise.GetUserByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            await _userServise.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteUser(int id)
        {
            var user = await _userServise.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            await _userServise.SoftDeleteUserAsync(id);
            return NoContent();
        }
    }
}
