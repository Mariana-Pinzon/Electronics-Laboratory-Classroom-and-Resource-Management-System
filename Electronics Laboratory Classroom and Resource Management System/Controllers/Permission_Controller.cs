using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Permission_Controller : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public Permission_Controller(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Permission>>> GetAllPermissions()
        {
            var permissions = await _permissionService.GetAllpermissionsAsync();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Permission>> GetPermissionById(int id)
        {
            var permission = await _permissionService.GetPermissionByIdAsync(id);
            if (permission == null)
                return NotFound();

            return Ok(permission);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<ActionResult> CreatePermission([FromQuery] int userTypeId, [FromQuery] int userPermissionId, [FromBody] Permission permission)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _permissionService.CreatePermissionAsync(userTypeId, userPermissionId, permission);
                return CreatedAtAction(nameof(GetPermissionById), new { id = permission.Permission_ID }, permission);
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid(); // Retorna 403 si no tiene permisos
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<IActionResult> UpdatePermission(int id, [FromQuery] int userTypeId, [FromQuery] int userPermissionId, [FromBody] Permission permission)
        {
            if (id != permission.Permission_ID)
                return BadRequest();

            var existingPermission = await _permissionService.GetPermissionByIdAsync(id);
            if (existingPermission == null)
                return NotFound();

            try
            {
                await _permissionService.UpdatePermissionAsync(userTypeId, userPermissionId, permission);
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
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<IActionResult> SoftDeletePermission(int id, [FromQuery] int userTypeId, [FromQuery] int userPermissionId)
        {
            var permission = await _permissionService.GetPermissionByIdAsync(id);
            if (permission == null)
                return NotFound();

            try
            {
                await _permissionService.SoftDeletePermissionAsync(userTypeId, userPermissionId, id);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid(); // Retorna 403 si no tiene permisos
            }
        }
    }
}
