using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Equipment_Controller : ControllerBase
    {
        private readonly Services.IEquipmentService _equipmentServise;
        public Equipment_Controller(Services.IEquipmentService equipmentService)
        {
            _equipmentServise = equipmentService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Equipment>>> GetAllEquipment()
        {
            var equipments = await _equipmentServise.GetAllEquipmentAsync();
            return Ok(equipments);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Equipment>> GetEquipmentById(int id)
        {
            var equipment = await _equipmentServise.GetEquipmentByIdAsync(id);
            if (equipment == null)
                return NotFound();

            return Ok(equipment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateEquipment([FromBody] Equipment equipment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _equipmentServise.CreateEquipmentAsync(equipment);
            return CreatedAtAction(nameof(GetEquipmentById), new { id = equipment.Equipment_ID }, equipment);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateEquipment(int id, [FromBody] Equipment equipment)
        {
            if (id != equipment.Equipment_ID)
                return BadRequest();

            var existingEquipment = await _equipmentServise.GetEquipmentByIdAsync(id);
            if (existingEquipment == null)
                return NotFound();

            await _equipmentServise.UpdateEquipmentAsync(equipment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteEquipment(int id)
        {
            var equipment = await _equipmentServise.GetEquipmentByIdAsync(id);
            if (equipment == null)
                return NotFound();

            await _equipmentServise.SoftDeleteEquipmentAsync(id);
            return NoContent();
        }
    }
}
