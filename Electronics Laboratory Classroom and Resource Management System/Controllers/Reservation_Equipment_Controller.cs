using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Reservation_Equipment_Controller : ControllerBase
    {
        private readonly IReservation_EquipmentService _reservation_equipmentServise;
        public Reservation_Equipment_Controller(IReservation_EquipmentService reservation_equipmentService)
        {
            _reservation_equipmentServise = reservation_equipmentService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Reservation_Equipment>>> GetAllreservations_equipment()
        {
            var reservation_equipment = await _reservation_equipmentServise.GetAllreservations_equipmentAsync();
            return Ok(reservation_equipment);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reservation_Equipment>> GetReservation_EquipmentById(int id)
        {
            var reservation_equipment = await _reservation_equipmentServise.GetReservation_EquipmentByIdAsync(id);
            if (reservation_equipment == null)
                return NotFound();

            return Ok(reservation_equipment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateReservation_Equipment([FromBody] Reservation_Equipment reservation_equipment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _reservation_equipmentServise.CreateReservation_EquipmentAsync(reservation_equipment);
            return CreatedAtAction(nameof(GetReservation_EquipmentById), new { id = reservation_equipment.ReservationE_ID }, reservation_equipment);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateReservation_Equipment(int id, [FromBody] Reservation_Equipment reservation_equipment)
        {
            if (id != reservation_equipment.ReservationE_ID)
                return BadRequest();

            var existingReservation_Equipment = await _reservation_equipmentServise.GetReservation_EquipmentByIdAsync(id);
            if (existingReservation_Equipment == null)
                return NotFound();

            await _reservation_equipmentServise.UpdateReservation_EquipmentAsync(reservation_equipment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteReservation_Equipment(int id)
        {
            var reservation_history = await _reservation_equipmentServise.GetReservation_EquipmentByIdAsync(id);
            if (reservation_history == null)
                return NotFound();

            await _reservation_equipmentServise.SoftDeleteReservation_EquipmentAsync(id);
            return NoContent();
        }
    }
}