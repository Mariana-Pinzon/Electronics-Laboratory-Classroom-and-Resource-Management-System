using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class User_Type_Controller : ControllerBase
    {
        private readonly IUser_TypeService _user_typeService;

        public User_Type_Controller(IUser_TypeService user_typeService)
        {
            _user_typeService = user_typeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User_Type>>> GetAllUserTypes()
        {
            var user_types = await _user_typeService.GetAlluser_typesAsync();
            return Ok(user_types);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User_Type>> GetUserTypeById(int id)
        {
            var user_type = await _user_typeService.GetUser_TypeByIdAsync(id);
            if (user_type == null)
                return NotFound();

            return Ok(user_type);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<ActionResult> CreateUserType(
            [FromQuery] int userTypeId,
            [FromQuery] int userPermissionId,
            [FromBody] User_Type user_type)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _user_typeService.CreateUser_TypeAsync(userTypeId, userPermissionId,user_type);
                return CreatedAtAction(nameof(GetUserTypeById), new { id = user_type.User_Type_ID }, user_type);
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
        public async Task<IActionResult> UpdateUserType(int id,
            [FromQuery] int userTypeId,
            [FromQuery] int userPermissionId,
            [FromBody] User_Type user_type)
        {
            if (id != user_type.User_Type_ID)
                return BadRequest();

            var existingUser_Type = await _user_typeService.GetUser_TypeByIdAsync(id);
            if (existingUser_Type == null)
                return NotFound();

            try
            {
                await _user_typeService.UpdateUser_TypeAsync(userTypeId, userPermissionId, user_type);
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
        public async Task<IActionResult> SoftDeleteUserType(int id,
            [FromQuery] int userTypeId,
            [FromQuery] int userPermissionId)
        {
            var user_type = await _user_typeService.GetUser_TypeByIdAsync(id);
            if (user_type == null)
                return NotFound();

            try
            {
                await _user_typeService.SoftDeleteUser_TypeAsync(userTypeId, userPermissionId, id);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid(); // Retorna 403 si no tiene permisos
            }
        }
    }
}
