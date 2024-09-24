using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class User_Permission_Controller : ControllerBase
    {
        private readonly Services.IUser_PermissionService _user_permissionServise;
        public User_Permission_Controller(Services.IUser_PermissionService user_permissionService)
        {
            _user_permissionServise = user_permissionService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<User_Permission>>> GetAllUser_Permission()
        {
            var user_permissions = await _user_permissionServise.GetAllUser_PermissionAsync();
            return Ok(user_permissions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User_Permission>> GetUser_PermissionById(int id)
        {
            var user_permission = await _user_permissionServise.GetUser_PermissionByIdAsync(id);
            if (user_permission == null)
                return NotFound();

            return Ok(user_permission);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUser_Permission([FromBody] User_Permission user_permission)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _user_permissionServise.CreateUser_PermissionAsync(user_permission);
            return CreatedAtAction(nameof(GetUser_PermissionById), new { id = user_permission.UserP_ID }, user_permission);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateUser_Permission(int id, [FromBody] User_Permission user_permission)
        {
            if (id != user_permission.UserP_ID)
                return BadRequest();

            var existingUser_Permission = await _user_permissionServise.GetUser_PermissionByIdAsync(id);
            if (existingUser_Permission == null)
                return NotFound();

            await _user_permissionServise.UpdateUser_PermissionAsync(user_permission);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteUser_Permission(int id)
        {
            var user_permission = await _user_permissionServise.GetUser_PermissionByIdAsync(id);
            if (user_permission == null)
                return NotFound();

            await _user_permissionServise.SoftDeleteUser_PermissionAsync(id);
            return NoContent();
        }
    }
}
