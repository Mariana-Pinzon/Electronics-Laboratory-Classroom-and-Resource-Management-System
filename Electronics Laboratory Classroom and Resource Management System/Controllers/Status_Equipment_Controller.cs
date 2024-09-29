using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Status_Equipment_Controller : ControllerBase
    {
        private readonly IStatus_EquipmentService _status_equipmentService;
        public Status_Equipment_Controller(IStatus_EquipmentService status_equipmentService)
        {
            _status_equipmentService = status_equipmentService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Status_Equipment>>> GetAllstatus_equipments()
        {
            var status_equipment = await _status_equipmentService.GetAllstatus_equipmentsAsync();
            return Ok(status_equipment);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Status_Equipment>> GetStatus_EquipmentById(int id)
        {
            var status_equipment = await _status_equipmentService.GetStatus_EquipmentByIdAsync(id);
            if (status_equipment == null)
                return NotFound();

            return Ok(status_equipment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateStatus_Equipment([FromBody] Status_Equipment status_equipment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _status_equipmentService.CreateStatus_EquipmentAsync(status_equipment);
            return CreatedAtAction(nameof(GetStatus_EquipmentById), new { id = status_equipment.StatusE_ID }, status_equipment);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateStatus_Equipment(int id, [FromBody] Status_Equipment status_equipment)
        {
            if (id != status_equipment.StatusE_ID)
                return BadRequest();

            var existingstatus_equipment = await _status_equipmentService.GetStatus_EquipmentByIdAsync(id);
            if (existingstatus_equipment == null)
                return NotFound();

            await _status_equipmentService.UpdateStatus_EquipmentAsync(status_equipment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteStatus_Equipment(int id)
        {
            var status_equipment = await _status_equipmentService.GetStatus_EquipmentByIdAsync(id);
            if (status_equipment == null)
                return NotFound();

            await _status_equipmentService.SoftDeleteStatus_EquipmentAsync(id);
            return NoContent();
        }
    }
}