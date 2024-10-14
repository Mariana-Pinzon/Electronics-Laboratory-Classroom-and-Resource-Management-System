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
        public async Task<ActionResult> CreateUserPermission(int UserTypeId, int permissionId, [FromBody] User_Permission user_permission)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _user_permissionService.CreateUser_PermissionAsync(UserTypeId, permissionId, user_permission);
                return CreatedAtAction(nameof(GetUserPermissionById), new { id = user_permission.UserP_ID }, user_permission);
            }

            catch (UnauthorizedAccessException)
            {
                return Forbid("You do not have permission to perform this action"); // Retorna 403 si no tiene permisos
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<IActionResult> UpdateUserPermission(int id, int UserTypeId, int permissionId)
        {

            var existingUser = await _user_permissionService.GetUser_PermissionByIdAsync(id);
            if (existingUser == null)
                return NotFound(); // Retorna 404 si el usuario no existe

            try
            {
                // Actualiza los datos del usuario
                await _user_permissionService.UpdateUser_PermissionAsync(id, UserTypeId, permissionId);
                return StatusCode(StatusCodes.Status200OK, "Updated Successfully"); // Retorna 200 si todo sale bien
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid("You do not have permission to perform this action"); // Retorna 403 si no tiene permisos
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message); // Retorna 500 para errores generales
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<IActionResult> SoftDeleteUserPermission(int id)
        {
            var user_permission = await _user_permissionService.GetUser_PermissionByIdAsync(id);
            if (user_permission == null)
                return NotFound();

            try
            {
                await _user_permissionService.SoftDeleteUser_PermissionAsync(id);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid("You do not have permission to perform this action"); // Retorna 403 si no tiene permisos
            }
        }
    }
}
