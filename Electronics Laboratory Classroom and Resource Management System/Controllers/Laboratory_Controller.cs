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
    public class Laboratory_Controller : ControllerBase
    {
        private readonly ILaboratoryService _laboratoryService;

        public Laboratory_Controller(ILaboratoryService laboratoryService)
        {
            _laboratoryService = laboratoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Laboratory>>> GetAlllaboratories()
        {
            var laboratories = await _laboratoryService.GetAlllaboratoriesAsync();
            return Ok(laboratories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Laboratory>> GetLaboratoryById(int id)
        {
            var laboratory = await _laboratoryService.GetLaboratoryByIdAsync(id);
            if (laboratory == null)
                return NotFound();

            return Ok(laboratory);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<ActionResult> CreateLaboratory([FromQuery] int userTypeId, [FromQuery] int userPermissionId, [FromBody] Laboratory laboratory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _laboratoryService.CreateLaboratoryAsync(userTypeId, userPermissionId, laboratory);
                return CreatedAtAction(nameof(GetLaboratoryById), new { id = laboratory.Laboratory_ID }, laboratory);
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
        public async Task<IActionResult> UpdateLaboratory(int id, [FromQuery] int userTypeId, [FromQuery] int userPermissionId, [FromBody] Laboratory laboratory)
        {
            if (id != laboratory.Laboratory_ID)
                return BadRequest();

            var existingLaboratory = await _laboratoryService.GetLaboratoryByIdAsync(id);
            if (existingLaboratory == null)
                return NotFound();

            try
            {
                await _laboratoryService.UpdateLaboratoryAsync(userTypeId, userPermissionId, laboratory);
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
        public async Task<IActionResult> SoftDeleteLaboratory(int id, [FromQuery] int userTypeId, [FromQuery] int userPermissionId)
        {
            var laboratory = await _laboratoryService.GetLaboratoryByIdAsync(id);
            if (laboratory == null)
                return NotFound();

            try
            {
                await _laboratoryService.SoftDeleteLaboratoryAsync(userTypeId, userPermissionId, id);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid(); // Retorna 403 si no tiene permisos
            }
        }
    }
}