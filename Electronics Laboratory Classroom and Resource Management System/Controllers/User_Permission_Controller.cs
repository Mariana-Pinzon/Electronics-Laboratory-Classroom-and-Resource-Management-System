using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class User_Permission_Controller : ControllerBase
    {
        private readonly IUser_PermissionService _user_permissionService;

        public User_Permission_Controller(IUser_PermissionService user_permissionService)
        {
            _user_permissionService = user_permissionService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User_Permission>>> GetAllUserPermissions()
        {
            var user_permissions = await _user_permissionService.GetAlluser_permissionsAsync();
            return Ok(user_permissions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User_Permission>> GetUserPermissionById(int id)
        {
            var user_permission = await _user_permissionService.GetUser_PermissionByIdAsync(id);
            if (user_permission == null)
                return NotFound();

            return Ok(user_permission);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<ActionResult> CreateUserPermission(
            [FromQuery] int userTypeId,
            [FromQuery] int userPermissionId,
            [FromBody] User_Permission user_permission)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _user_permissionService.CreateUser_PermissionAsync(userTypeId, userPermissionId,user_permission);
                return CreatedAtAction(nameof(GetUserPermissionById), new { id = user_permission.UserP_ID }, user_permission);
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
        public async Task<IActionResult> UpdateUserPermission(int id,[FromQuery] int userTypeId,[FromQuery] int userPermissionId, [FromBody] User_Permission user_permission)
        {
            if (id != user_permission.UserP_ID)
                return BadRequest();

            var existingUser_Permission = await _user_permissionService.GetUser_PermissionByIdAsync(id);
            if (existingUser_Permission == null)
                return NotFound();

            try
            {
                await _user_permissionService.UpdateUser_PermissionAsync(userTypeId, userPermissionId,user_permission);
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
        public async Task<IActionResult> SoftDeleteUserPermission(int id, [FromQuery] int userTypeId, [FromQuery] int userPermissionId)
        {
            var user_permission = await _user_permissionService.GetUser_PermissionByIdAsync(id);
            if (user_permission == null)
                return NotFound();

            try
            {
                await _user_permissionService.SoftDeleteUser_PermissionAsync(userTypeId, userPermissionId,id);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid(); // Retorna 403 si no tiene permisos
            }
        }
    }
}
