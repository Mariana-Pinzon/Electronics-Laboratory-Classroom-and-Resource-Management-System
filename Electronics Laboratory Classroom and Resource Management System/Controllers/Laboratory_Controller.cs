using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


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
            try
            {
                var laboratories = await _laboratoryService.GetAlllaboratoriesAsync();
                return Ok(laboratories);
            }
            catch (Exception e)
            {

                throw;
            }
            
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
        public async Task<ActionResult> CreateLaboratory(int Laboratory_Num, int Capacity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                 await _laboratoryService.CreateLaboratoryAsync(Laboratory_Num, Capacity);
                
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid("You do not have permission to perform this action"); // Retorna 403 si no tiene permisos
            }
            return StatusCode(StatusCodes.Status201Created, "Laboratory created succesfully");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<IActionResult> UpdateLaboratory(int id, int Laboratory_Num, int Capacity)
        {
            var existingLaboratory = await _laboratoryService.GetLaboratoryByIdAsync(id);
            if (existingLaboratory == null)
                return NotFound();

            try
            {
                await _laboratoryService.UpdateLaboratoryAsync(id,Laboratory_Num, Capacity);
                return StatusCode(StatusCodes.Status200OK, "Updated Successfully");
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid("You do not have permission to perform this action"); // Retorna 403 si no tiene permisos
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<IActionResult> SoftDeleteLaboratory(int id)
        {
            var laboratory = await _laboratoryService.GetLaboratoryByIdAsync(id);
            if (laboratory == null)
                return NotFound();

            try
            {
                await _laboratoryService.SoftDeleteLaboratoryAsync(id);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid("You do not have permission to perform this action"); // Retorna 403 si no tiene permisos
            }
        }
    }
}