using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Equipment_Controller : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public Equipment_Controller(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetAllequipments()
        {
            var equipments = await _equipmentService.GetAllequipmentsAsync();
            return Ok(equipments);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Equipment>> GetEquipmentById(int id)
        {
            var equipment = await _equipmentService.GetEquipmentByIdAsync(id);
            if (equipment == null)
                return NotFound();

            return Ok(equipment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<ActionResult> CreateEquipment(string Equipment_Name, string Description, int StatusE_ID, DateOnly Acquisition_date, int Laboratory_ID, [FromBody] Equipment equipment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _equipmentService.CreateEquipmentAsync(Equipment_Name, Description, StatusE_ID, Acquisition_date, Laboratory_ID, equipment);
                return CreatedAtAction(nameof(GetEquipmentById), new { id = equipment.Equipment_ID }, equipment);
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
        public async Task<IActionResult> UpdateEquipment(int id, string Equipment_Name, string Description, int StatusE_ID, DateOnly Acquisition_date, int Laboratory_ID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingEquipment = await _equipmentService.GetEquipmentByIdAsync(id);
            if (existingEquipment == null)
                return NotFound();

            try
            {
                await _equipmentService.UpdateEquipmentAsync(id, Equipment_Name, Description, StatusE_ID, Acquisition_date, Laboratory_ID);
                return StatusCode(StatusCodes.Status200OK, "Updated Successfully");
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // Para manejo de errores de autorización
        public async Task<IActionResult> SoftDeleteEquipment(int id)
        {
            var equipment = await _equipmentService.GetEquipmentByIdAsync(id);
            if (equipment == null)
                return NotFound();

            try
            {
                await _equipmentService.SoftDeleteEquipmentAsync( id);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid(); // Retorna 403 si no tiene permisos
            }
        }
    }
}