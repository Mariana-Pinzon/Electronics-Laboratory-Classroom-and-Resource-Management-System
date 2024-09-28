using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Permission_Controller : ControllerBase
    {
        private readonly Services.IPermissionService _permissionServise;
        public Permission_Controller(Services.IPermissionService permissionService)
        {
            _permissionServise = permissionService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Permission>>> GetAllPermission()
        {
            var permissions = await _permissionServise.GetAllPermissionAsync();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Permission>> GetPermissionById(int id)
        {
            var permission = await _permissionServise.GetPermissionByIdAsync(id);
            if (permission == null)
                return NotFound();

            return Ok(permission);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePermission([FromBody] Permission permission)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _permissionServise.CreatePermissionAsync(permission);
            return CreatedAtAction(nameof(GetPermissionById), new { id = permission.Permission_ID }, permission);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdatePermission(int id, [FromBody] Permission permission)
        {
            if (id != permission.Permission_ID)
                return BadRequest();

            var existingPermission = await _permissionServise.GetPermissionByIdAsync(id);
            if (existingPermission == null)
                return NotFound();

            await _permissionServise.UpdatePermissionAsync(permission);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeletePermission(int id)
        {
            var permission = await _permissionServise.GetPermissionByIdAsync(id);
            if (permission == null)
                return NotFound();

            await _permissionServise.SoftDeletePermissionAsync(id);
            return NoContent();
        }
    }
}
